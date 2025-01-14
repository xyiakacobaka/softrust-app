using MediatR;
using MessageFormApi.Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Messages.Queries.GetMessagesByThemeIdQuery
{
    public class GetMessagesByThemeIdQuery : IRequest<IEnumerable<MessageDto>>
    {
        public int ThemeId { get; set; }
    }
}
