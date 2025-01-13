using MediatR;
using MessageFormApi.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Commands.UpdateContactCommand
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Unit>
    {
        private readonly MessageFormApiDbContext _context;

        public UpdateContactCommandHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts.FindAsync(request.Id, cancellationToken);

            if (contact == null)
            {
                throw new Exception("Contact not found");
            }

            contact.UserName = request.UserName;
            contact.Email = request.Email;
            contact.PhoneNumber = request.PhoneNumber;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
