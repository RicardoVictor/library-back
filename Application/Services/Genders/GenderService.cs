
using System.Net;
using Library.Application.Interfaces.Services.Genders;
using Library.Application.Models.Base;
using Library.Application.Models.Genders.Request;
using Library.Application.Models.Genders.Response;
using Library.Application.Services.Base;
using Library.Domain.Common;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Services.Genders;

public class GenderService : BaseService, IGenderService
{
    private readonly IGenderRepository _repository;

    public GenderService(IGenderRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse<PagedList<GenderResponse>>> GetAsync(GenderFilterRequest filter)
    {
        PagedList<GenderResponse> result;

        if (filter.PageNumber != null && filter.PageSize != null)
        {
            var genders = await _repository.GetPagedAsync(filter);

            result = new PagedList<GenderResponse>(
                genders.PageNumber,
                genders.PageSize,
                genders.TotalItems,
                genders.TotalPages,
                genders.Items.Select(x => (GenderResponse)x));
        }
        else
        {
            var genders = await _repository.GetFilteredAsync(filter);

            result = new PagedList<GenderResponse>(
                1,
                genders.Count(),
                genders.Count(),
                1,
                genders.Select(x => (GenderResponse)x));
        }

        return SetSuccessResponse(HttpStatusCode.OK, result);
    }
}

