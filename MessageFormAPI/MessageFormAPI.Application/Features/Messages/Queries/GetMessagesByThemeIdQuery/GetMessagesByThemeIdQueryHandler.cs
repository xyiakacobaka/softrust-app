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

namespace MessageFormApi.Application.Features.Messages.Queries.GetMessagesByThemeIdQuery
{
    public class GetMessagesByThemeIdQueryHandler : IRequestHandler<GetMessagesByThemeIdQuery, IEnumerable<MessageDto>>
    {
        private readonly MessageFormApiDbContext _context;
        private readonly IMapper _mapper;

        public GetMessagesByThemeIdQueryHandler(MessageFormApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageDto>> Handle(GetMessagesByThemeIdQuery request, CancellationToken cancellationToken)
        {
            var messages = await _context.Messages
                .Where(m => m.ThemeId == request.ThemeId) // Фильтрация по ThemeId
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MessageDto>>(messages);
        }
    }
}
