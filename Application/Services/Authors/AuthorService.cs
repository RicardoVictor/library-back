
using System.Net;
using Library.Application.Interfaces.Services.Authors;
using Library.Application.Models.Authors.Request;
using Library.Application.Models.Authors.Response;
using Library.Application.Models.Base;
using Library.Application.Models.Books.Request;
using Library.Application.Services.Base;
using Library.Domain.Common;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Repositories.Base;

namespace Library.Application.Services.Authors;

public class AuthorService : BaseService, IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthorRepository _repository;
    private readonly IAuthorValidationService _authorValidationService;


    public AuthorService(IUnitOfWork unitOfWork, IAuthorRepository repository, IAuthorValidationService authorValidationService)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _authorValidationService = authorValidationService;
    }

    public async Task<BaseResponse<PagedList<AuthorResponse>>> GetAsync(AuthorFilterRequest filter)
    {
        PagedList<AuthorResponse> result;

        if (filter.PageNumber != null && filter.PageSize != null)
        {
            var authors = await _repository.GetPagedAsync(filter);

            result = new PagedList<AuthorResponse>(
                authors.PageNumber,
                authors.PageSize,
                authors.TotalItems,
                authors.TotalPages,
                authors.Items.Select(x => (AuthorResponse)x));
        }
        else
        {
            var authors = await _repository.GetFilteredAsync(filter);

            result = new PagedList<AuthorResponse>(
                1,
                authors.Count(),
                authors.Count(),
                1,
                authors.Select(x => (AuthorResponse)x));
        }

        return SetSuccessResponse(HttpStatusCode.OK, result);
    }

    public async Task<BaseResponse<AuthorResponse>> GetByIdAsync(Guid id)
    {
        var (author, error) = await _authorValidationService.ValidateExistsAsync(id);

        if (author is null) return SetErrorResponse<AuthorResponse>(HttpStatusCode.NotFound, error);

        return SetSuccessResponse(HttpStatusCode.OK, (AuthorResponse)author);
    }

    public async Task<BaseResponse<Guid>> PostAsync(AuthorPostRequest request)
    {
        var author = new Author(request.Name!);

        await _repository.AddAsync(author);

        await _unitOfWork.CommitAsync();

        return SetSuccessResponse(HttpStatusCode.Created, author.Id);
    }

    public async Task<BaseResponse<Guid>> UpdateAsync(Guid id, AuthorUpdateRequest request)
    {
        var (author, errorAuthor) = await _authorValidationService.ValidateExistsAsync(id);
        if (author is null) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, errorAuthor);

        if (await _repository.ExistsAsync(x => x.Id != author.Id && x.Name == request.Name)) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, $"Nome '{request.Name}' já está em uso no sistema.");

        author.Name = request.Name!;

        _repository.Update(author);

        await _unitOfWork.CommitAsync();

        return SetSuccessResponse(HttpStatusCode.OK, author.Id);
    }

    public async Task<BaseResponse<Guid>> DeleteAsync(Guid id)
    {
        var (author, errorAuthor) = await _authorValidationService.ValidateExistsAsync(id);
        if (author is null) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, errorAuthor);

        _repository.Remove(author);

        await _unitOfWork.CommitAsync();

        return SetSuccessResponse(HttpStatusCode.NoContent, author.Id);
    }
}

