
using System.Net;
using Library.Application.Interfaces.Services.Authors;
using Library.Application.Models.Authors.Request;
using Library.Application.Models.Authors.Response;
using Library.Application.Models.Base;
using Library.Application.Services.Base;
using Library.Domain.Common;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Services.Authors;

public class AuthorService : BaseService, IAuthorService
{
    private readonly IAuthorRepository _repository;

    public AuthorService(IAuthorRepository repository)
    {
        _repository = repository;
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
}

