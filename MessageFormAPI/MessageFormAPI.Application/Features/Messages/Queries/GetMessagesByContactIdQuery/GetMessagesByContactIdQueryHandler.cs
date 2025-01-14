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

namespace MessageFormApi.Application.Features.Messages.Queries.GetMessagesByContactIdQuery
{
    public class GetMessagesByContactIdQueryHandler : IRequestHandler<GetMessagesByContactIdQuery, IEnumerable<MessageDto>>
    {
        private readonly MessageFormApiDbContext _context;
        private readonly IMapper _mapper;

        public GetMessagesByContactIdQueryHandler(MessageFormApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageDto>> Handle(GetMessagesByContactIdQuery request, CancellationToken cancellationToken)
        {
            var messages = await _context.Messages
                .Where(m => m.ContactId == request.ContactId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MessageDto>>(messages);
        }
    }
}
