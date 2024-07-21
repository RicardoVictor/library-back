using Library.Application.Models.Authors.Request;
using Library.Application.Models.Authors.Response;
using Library.Application.Models.Base;
using Library.Application.Models.Books.Request;
using Library.Domain.Common;

namespace Library.Application.Interfaces.Services.Authors;

public interface IAuthorService
{
    Task<BaseResponse<PagedList<AuthorResponse>>> GetAsync(AuthorFilterRequest filter);
    Task<BaseResponse<AuthorResponse>> GetByIdAsync(Guid id);
    Task<BaseResponse<Guid>> PostAsync(AuthorPostRequest request);
    Task<BaseResponse<Guid>> UpdateAsync(Guid id, AuthorUpdateRequest request);
    Task<BaseResponse<Guid>> DeleteAsync(Guid id);
}
