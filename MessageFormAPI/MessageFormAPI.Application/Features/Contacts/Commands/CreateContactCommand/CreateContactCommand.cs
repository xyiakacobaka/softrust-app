using MediatR;
using MessageFormApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Commands.CreateContactCommand
{
    public class CreateContactCommand : IRequest<Contact>
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
