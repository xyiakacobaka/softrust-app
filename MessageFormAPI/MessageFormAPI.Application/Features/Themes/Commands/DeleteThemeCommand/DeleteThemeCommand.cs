using MediatR;
using MessageFormApi.Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Themes.Commands.DeleteThemeCommand
{
    public class DeleteThemeCommand : IRequest<DeleteResultDto>
    {
        public int Id { get; set; }
    }
}
