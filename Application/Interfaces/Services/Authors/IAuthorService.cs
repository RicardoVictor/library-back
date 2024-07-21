using Library.Application.Models.Authors.Request;
using Library.Application.Models.Authors.Response;
using Library.Application.Models.Base;
using Library.Domain.Common;

namespace Library.Application.Interfaces.Services.Authors;

public interface IAuthorService
{
    Task<BaseResponse<PagedList<AuthorResponse>>> GetAsync(AuthorFilterRequest filter);
}
