using MediatR;
using MessageFormApi.Application.Features.Messages.Queries;
using MessageFormApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Messages.Commands.CreateMessageCommand
{
    public class CreateMessageCommand : IRequest<MessageDto>
    {
        public string Content { get; set; }
        public int ThemeId { get; set; }
        public int ContactId { get; set; }
    }
}
