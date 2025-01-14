using AutoMapper;
using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MessageFormApi.Application.Features.Themes.Queries.GetAllThemesQuery
{
    public class GetAllThemesQueryHandler : IRequestHandler<GetAllThemesQuery, IEnumerable<ThemeDto>>
    {
        private readonly MessageFormApiDbContext _context;
        private readonly IMapper _mapper;

        public GetAllThemesQueryHandler(MessageFormApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ThemeDto>> Handle(GetAllThemesQuery request, CancellationToken cancellationToken)
        {
            var themes = await _context.Themes.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ThemeDto>>(themes);
        }
    }
}
