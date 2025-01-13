using MediatR;
using MessageFormApi.Domain.Models;

namespace MessageFormApi.Application.Features.Themes.Commands.CreateThemeCommand
{
    public class CreateThemeCommand : IRequest<Theme>
    {
        public string ThemeLabel { get; set; }
    }
}