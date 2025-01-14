using MediatR;
using MessageFormApi.Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Themes.Commands.DeleteAllThemesCommand
{
    public class DeleteAllThemesCommand : IRequest<DeleteResultDto>
    {
    }
}
