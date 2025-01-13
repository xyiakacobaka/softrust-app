using MediatR;
using MessageFormApi.Application.Features.Messages.Commands.CreateMessageCommand;
using MessageFormApi.Application.Features.Messages.Queries;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace MessageFormAPI.Application.Features.Messages.Commands
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, MessageDto>
    {
        private readonly MessageFormApiDbContext _context;

        public CreateMessageCommandHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<MessageDto> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            // Получаем Theme и Contact из базы данных
            var theme = await _context.Themes.FindAsync(request.ThemeId, cancellationToken);
            var contact = await _context.Contacts.FindAsync(request.ContactId, cancellationToken);

            if (theme == null || contact == null)
            {
                throw new Exception("Theme or Contact not found");
            }

            // Создаём объект Message
            var message = new Message
            {
                Content = request.Content,
                Theme = theme,
                Contact = contact
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync(cancellationToken);

            // Преобразуем Message в MessageDto
            return new MessageDto
            {
                Id = message.Id,
                Content = message.Content,
                ThemeId = message.ThemeId,
                ContactId = message.ContactId,
                CreatedAt = message.CreatedAt,
                UpdatedAt = message.UpdatedAt
            };
        }
    }
}