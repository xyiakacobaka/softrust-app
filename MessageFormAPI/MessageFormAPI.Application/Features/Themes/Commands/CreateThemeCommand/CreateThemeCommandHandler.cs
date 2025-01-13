using MediatR;
using MessageFormApi.Application.Features.Themes.Commands.CreateThemeCommand;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace MessageFormAPI.Application.Features.Themes.Commands
{
    public class CreateThemeCommandHandler : IRequestHandler<CreateThemeCommand, Theme>
    {
        private readonly MessageFormApiDbContext _context;

        public CreateThemeCommandHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<Theme> Handle(CreateThemeCommand request, CancellationToken cancellationToken)
        {
            var theme = new Theme { ThemeLabel = request.ThemeLabel };
            _context.Themes.Add(theme);
            await _context.SaveChangesAsync(cancellationToken);
            return theme;
        }
    }
}