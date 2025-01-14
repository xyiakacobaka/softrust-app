using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Themes.Commands.UpdateThemeCommand
{
    public class UpdateThemeCommand : IRequest<ThemeDto>
    {
        public int Id { get; set; }
        public string ThemeLabel { get; set; }
    }
}
