using MediatR;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MessageFormApi.Application.Features.Themes.Queries.GetAllThemesQuery
{
    public class GetAllThemesQueryHandler : IRequestHandler<GetAllThemesQuery, IEnumerable<Theme>>
    {
        private readonly MessageFormApiDbContext _context;

        public GetAllThemesQueryHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Theme>> Handle(GetAllThemesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Themes.ToListAsync(cancellationToken);
        }
    }
}
