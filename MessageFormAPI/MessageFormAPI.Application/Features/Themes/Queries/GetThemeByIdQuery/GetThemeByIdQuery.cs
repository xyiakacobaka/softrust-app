using MediatR;
using MessageFormApi.Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Themes.Queries.GetThemeByIdQuery
{
    public class GetThemeByIdQuery : IRequest<ThemeDto>
    {
        public int Id { get; set; }
    }
}
