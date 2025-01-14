using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageFormApi.Application.Features.DTOs;

namespace MessageFormApi.Application.Features.Messages.Queries.GetMessageByIdQuery
{
    public class GetMessageByIdQuery : IRequest<MessageDto>
    {
        public int Id { get; set; }
    }
}
