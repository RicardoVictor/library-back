
using System.Net;
using Library.Application.Interfaces.Services.Genders;
using Library.Application.Models.Base;
using Library.Application.Models.Books.Request;
using Library.Application.Models.Genders.Request;
using Library.Application.Models.Genders.Response;
using Library.Application.Services.Base;
using Library.Domain.Common;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Repositories.Base;

namespace Library.Application.Services.Genders;

public class GenderService : BaseService, IGenderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenderRepository _repository;
    private readonly IGenderValidationService _genderValidationService;


    public GenderService(IUnitOfWork unitOfWork, IGenderRepository repository, IGenderValidationService genderValidationService)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _genderValidationService = genderValidationService;
    }

    public async Task<BaseResponse<PagedList<GenderResponse>>> GetAsync(GenderFilterRequest filter)
    {
        PagedList<GenderResponse> result;

        if (filter.PageNumber != null && filter.PageSize != null)
        {
            var genders = await _repository.GetPagedAsync(filter);

            result = new PagedList<GenderResponse>(
                genders.Items.Any() ? genders.PageNumber : 0,
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

    public async Task<BaseResponse<GenderResponse>> GetByIdAsync(Guid id)
    {
        var (gender, error) = await _genderValidationService.ValidateExistsAsync(id);

        if (gender is null) return SetErrorResponse<GenderResponse>(HttpStatusCode.NotFound, error);

        return SetSuccessResponse(HttpStatusCode.OK, (GenderResponse)gender);
    }

    public async Task<BaseResponse<Guid>> PostAsync(GenderPostRequest request)
    {
        var gender = new Gender(request.Name!);

        if (await _repository.ExistsAsync(x => x.Name == request.Name)) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, $"Gênero com nome '{request.Name}' já cadastrado no sistema.");

        await _repository.AddAsync(gender);

        await _unitOfWork.CommitAsync();

        return SetSuccessResponse(HttpStatusCode.Created, gender.Id);
    }

    public async Task<BaseResponse<Guid>> UpdateAsync(Guid id, GenderUpdateRequest request)
    {
        var (gender, errorGender) = await _genderValidationService.ValidateExistsAsync(id);
        if (gender is null) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, errorGender);

        if (await _repository.ExistsAsync(x => x.Id != gender.Id && x.Name == request.Name)) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, $"Nome '{request.Name}' já está em uso no sistema.");

        gender.Name = request.Name!;

        _repository.Update(gender);

        await _unitOfWork.CommitAsync();

        return SetSuccessResponse(HttpStatusCode.OK, gender.Id);
    }

    public async Task<BaseResponse<Guid>> DeleteAsync(Guid id)
    {
        var (gender, errorGender) = await _genderValidationService.ValidateExistsAsync(id);
        if (gender is null) return SetErrorResponse<Guid>(HttpStatusCode.BadRequest, errorGender);

        _repository.Remove(gender);

        await _unitOfWork.CommitAsync();

        return SetSuccessResponse(HttpStatusCode.NoContent, gender.Id);
    }
}

