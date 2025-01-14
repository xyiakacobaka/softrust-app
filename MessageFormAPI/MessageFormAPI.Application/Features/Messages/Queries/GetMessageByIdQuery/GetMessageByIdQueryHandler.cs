using MediatR;
using MessageFormApi.Application.Features.Messages.Queries.GetMessageByIdQuery;
using MessageFormApi.Application.Features.Messages.Queries;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using MessageFormApi.Application.Features.DTOs;

namespace MessageFormAPI.Application.Features.Messages.Queries
{
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, MessageDto>
    {
        private readonly MessageFormApiDbContext _context;

        public GetMessageByIdQueryHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<MessageDto> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await _context.Messages
                .Include(m => m.Theme)
                .Include(m => m.Contact)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (message == null)
            {
                throw new Exception("Message not found");
            }

            // Преобразуем Message в MessageDto
            return new MessageDto
            {
                Id = message.Id,
                Content = message.Content,
                ThemeId = message.ThemeId,
                ContactId = message.ContactId,

            };
        }
    }
}