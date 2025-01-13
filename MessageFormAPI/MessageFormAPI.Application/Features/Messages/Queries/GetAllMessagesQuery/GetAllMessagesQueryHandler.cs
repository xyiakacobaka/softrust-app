using MediatR;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Messages.Queries.GetAllMessagesQuery
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, IEnumerable<Message>>
    {
        private readonly MessageFormApiDbContext _context;

        public GetAllMessagesQueryHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Messages
                .Include(m => m.Theme)
                .Include(m => m.Contact)
                .ToListAsync(cancellationToken);
        }
    }
}
