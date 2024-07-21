using Library.Application.Models.Base;
using Library.Application.Models.Books.Request;
using Library.Application.Models.Books.Response;
using Library.Domain.Common;

namespace Library.Application.Interfaces.Services.Books;

public interface IBookService
{
    Task<BaseResponse<PagedList<BookResponse>>> GetAsync(BookFilterRequest filter);
    Task<BaseResponse<BookResponse>> GetByIdAsync(Guid id);
    Task<BaseResponse<Guid>> PostAsync(BookPostRequest request);
    Task<BaseResponse<Guid>> UpdateAsync(Guid id, BookUpdateRequest request);
    Task<BaseResponse<Guid>> DeleteAsync(Guid id);
}
