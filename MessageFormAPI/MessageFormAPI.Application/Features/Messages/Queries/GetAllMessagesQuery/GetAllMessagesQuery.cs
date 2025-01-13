using MediatR;
using MessageFormApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Messages.Queries.GetAllMessagesQuery
{
    public class GetAllMessagesQuery : IRequest<IEnumerable<Message>>
    {
    }
}
