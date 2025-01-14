using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Domain.Models;

namespace MessageFormApi.Application.Features.Themes.Commands.CreateThemeCommand
{
    public class CreateThemeCommand : IRequest<ThemeDto>
    {
        public string ThemeLabel { get; set; }
    }
}