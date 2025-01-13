using MediatR;
using MessageFormApi.Domain.Models;

namespace MessageFormApi.Application.Features.Themes.Queries.GetAllThemesQuery
{
    public class GetAllThemesQuery : IRequest<IEnumerable<Theme>>
    {
    }
}
