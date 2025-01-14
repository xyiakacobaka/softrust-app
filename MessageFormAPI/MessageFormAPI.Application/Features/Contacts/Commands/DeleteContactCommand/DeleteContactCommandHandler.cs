using MediatR;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Commands.DeleteContactCommand
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, bool>
    {
        private readonly MessageFormApiDbContext _context;

        public DeleteContactCommandHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (contact == null)
                return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
