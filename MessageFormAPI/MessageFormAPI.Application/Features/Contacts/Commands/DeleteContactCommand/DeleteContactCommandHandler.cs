using MediatR;
using MessageFormApi.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Commands.DeleteContactCommand
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly MessageFormApiDbContext _context;

        public DeleteContactCommandHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts.FindAsync(request.Id, cancellationToken);

            if (contact == null)
            {
                throw new Exception("Contact not found");
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
