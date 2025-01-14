using MediatR;
using MessageFormApi.Application.Features.DTOs;

namespace MessageFormApi.Application.Features.Contacts.Commands.UpdateContactCommand
{
    public class UpdateContactCommand : IRequest<ContactDto>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
