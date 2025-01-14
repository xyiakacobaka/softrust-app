using MediatR;
using MessageFormApi.Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Queries.GetContactByIdQuery
{
    public class GetContactByIdQuery : IRequest<ContactDto>
    {
        public int Id { get; set; }
    }
}
