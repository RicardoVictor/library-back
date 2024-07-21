using Library.Application.Models.Base;
using Library.Application.Models.Books.Request;
using Library.Application.Models.Genders.Request;
using Library.Application.Models.Genders.Response;
using Library.Domain.Common;

namespace Library.Application.Interfaces.Services.Genders;

public interface IGenderService
{
    Task<BaseResponse<PagedList<GenderResponse>>> GetAsync(GenderFilterRequest filter);
    Task<BaseResponse<GenderResponse>> GetByIdAsync(Guid id);
    Task<BaseResponse<Guid>> PostAsync(GenderPostRequest request);
    Task<BaseResponse<Guid>> UpdateAsync(Guid id, GenderUpdateRequest request);
    Task<BaseResponse<Guid>> DeleteAsync(Guid id);
}
