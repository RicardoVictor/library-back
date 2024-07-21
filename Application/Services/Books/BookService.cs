using System.Net;
using Library.Application.Interfaces.Services.Authors;
using Library.Application.Interfaces.Services.Books;
using Library.Application.Interfaces.Services.Genders;
using Library.Application.Models.Base;
using Library.Application.Models.Books.Request;
using Library.Application.Models.Books.Response;
using Library.Application.Services.Base;
using Library.Domain.Common;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Repositories.Base;

namespace Library.Application.Services.Books;

public class BookService : BaseService, IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _repository;
    private readonly IBookValidationService _bookValidationService;
    private readonly IGenderValidationService _genderValidationService;
    private readonly IAuthorValidationService _authorValidationService;

    public BookService(
        IUnitOfWork unitOfWork,
        IBookRepository repository,
        IBookValidationService bookValidationService,
        IGenderValidationService genderValidationService,
        IAuthorValidationService authorValidationService)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _bookValidationService = bookValidationService;
        _genderValidationService = genderValidationService;
        _authorValidationService = authorValidationService;
    }

    public async Task<BaseResponse<PagedList<BookResponse>>> GetAsync(BookFilterRequest filter)
    {
        PagedList<BookResponse> result;

        if (filter.PageNumber != null && filter.PageSize != null)
        {
            var books = await _repository.GetPagedAsync(filter);

            result = new PagedList<BookResponse>(
                books.PageNumber,
                books.PageSize,
                books.TotalItems,
                books.TotalPages,
                books.Items.Select(x => (BookResponse)x));
        }
        else
        {
            var books = await _repository.GetFilteredAsync(filter);

            result = new PagedList<BookResponse>(
                1,
                books.Count(),
                books.Count(),
                1,
                books.Select(x => (BookResponse)x));
        }

        return SetSuccessResponse(HttpStatusCode.OK, result);
    }

    public async Task<BaseResponse<BookResponse>> GetByIdAsync(Guid id)
    {
        var (book, error) = await _bookValidationService.ValidateExistsAsync(id);

        if (book is null) return SetErrorResponse<BookResponse>(HttpStatusCode.NotFound, error);

        return SetSuccessResponse(HttpStatusCode.OK, (BookResponse)book);
    }

    public async Task<BaseResponse<Guid>> PostAsync(BookPostRequest request)
    {
        var (author, errorAuthor) = await _authorValidationService.ValidateExistsAsync(request.AuthorId);
        if (author is null) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, errorAuthor);

        var (gender, errorGender) = await _genderValidationService.ValidateExistsAsync(request.GenderId);
        if (gender is null) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, errorGender);

        if (await _repository.ExistsAsync(x => x.Name == request.Name)) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, $"Usuário com nome '{request.Name}' já cadastrado no sistema.");

        var book = new Book(
            request.Name!,
            request.GenderId,
            request.AuthorId);

        await _repository.AddAsync(book);

        await _unitOfWork.CommitAsync();

        return SetSuccessResponse(HttpStatusCode.Created, book.Id);
    }

    public async Task<BaseResponse<Guid>> UpdateAsync(Guid id, BookUpdateRequest request)
    {
        var (book, errorBook) = await _bookValidationService.ValidateExistsAsync(id);
        if (book is null) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, errorBook);

        var (author, errorAuthor) = await _authorValidationService.ValidateExistsAsync(request.AuthorId);
        if (author is null) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, errorAuthor);

        var (gender, errorGender) = await _genderValidationService.ValidateExistsAsync(request.GenderId);
        if (gender is null) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, errorGender);

        if (await _repository.ExistsAsync(x => x.Id != book.Id && x.Name == request.Name)) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, $"Nome '{request.Name}' já está em uso no sistema.");

        book.Name = request.Name!;
        book.GenderId = request.GenderId;
        book.AuthorId = request.AuthorId;

        _repository.Update(book);

        await _unitOfWork.CommitAsync();

        return SetSuccessResponse(HttpStatusCode.OK, book.Id);
    }

    public async Task<BaseResponse<Guid>> DeleteAsync(Guid id)
    {
        var (book, errorBook) = await _bookValidationService.ValidateExistsAsync(id);
        if (book is null) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, errorBook);

        _repository.Remove(book);

        await _unitOfWork.CommitAsync();

        return SetSuccessResponse(HttpStatusCode.NoContent, book.Id);
    }
}
