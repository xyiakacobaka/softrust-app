using MediatR;
using MessageFormApi.Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Commands.CreateContactCommand
{
    public class CreateContactCommand : IRequest<ContactDto>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
