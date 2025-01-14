using MediatR;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MessageFormApi.Application.Features.DTOs;

namespace MessageFormApi.Application.Features.Messages.Queries.GetAllMessagesQuery
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, IEnumerable<MessageDto>>
    {
        private readonly MessageFormApiDbContext _context;

        public GetAllMessagesQueryHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MessageDto>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await _context.Messages
                .Include(m => m.Theme)
                .Include(m => m.Contact)
                .ToListAsync(cancellationToken);

            // Преобразование сущностей в DTO
            return messages.Select(m => new MessageDto
            {
                Id = m.Id,
                Content = m.Content,
                ThemeId = m.ThemeId,
                ContactId = m.ContactId,
            });
        }
    }
}
