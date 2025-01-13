using MediatR;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Commands.CreateContactCommand
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Contact>
    {
        private readonly MessageFormApiDbContext _context;

        public CreateContactCommandHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync(cancellationToken);

            return contact;
        }
    }
}
