using Library.Application.Models.Base;
using Library.Application.Models.Genders.Request;
using Library.Application.Models.Genders.Response;
using Library.Domain.Common;

namespace Library.Application.Interfaces.Services.Genders;

public interface IGenderService
{
    Task<BaseResponse<PagedList<GenderResponse>>> GetAsync(GenderFilterRequest filter);
}
