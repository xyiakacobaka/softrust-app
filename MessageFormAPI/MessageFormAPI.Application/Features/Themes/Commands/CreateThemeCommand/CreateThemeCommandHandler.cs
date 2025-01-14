using AutoMapper;
using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Application.Features.Themes.Commands.CreateThemeCommand;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace MessageFormAPI.Application.Features.Themes.Commands
{
    public class CreateThemeCommandHandler : IRequestHandler<CreateThemeCommand, ThemeDto>
    {
        private readonly MessageFormApiDbContext _context;
        private readonly IMapper _mapper;

        public CreateThemeCommandHandler(MessageFormApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ThemeDto> Handle(CreateThemeCommand request, CancellationToken cancellationToken)
        {
            var theme = new Theme { ThemeLabel = request.ThemeLabel };
            _context.Themes.Add(theme);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ThemeDto>(theme);
        }
    }
}