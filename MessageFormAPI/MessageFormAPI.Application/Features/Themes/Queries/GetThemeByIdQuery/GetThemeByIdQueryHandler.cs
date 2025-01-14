using AutoMapper;
using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Themes.Queries.GetThemeByIdQuery
{
    public class GetThemeByIdQueryHandler : IRequestHandler<GetThemeByIdQuery, ThemeDto>
    {
        private readonly MessageFormApiDbContext _context;
        private readonly IMapper _mapper;

        public GetThemeByIdQueryHandler(MessageFormApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ThemeDto> Handle(GetThemeByIdQuery request, CancellationToken cancellationToken)
        {
            var theme = await _context.Themes
                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            return _mapper.Map<ThemeDto>(theme);
        }
    }
}
