using MediatR;
using MessageFormApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Queries.GetContactByIdQuery
{
    public class GetContactByIdQuery : IRequest<Contact>
    {
        public int Id { get; set; }
    }
}
