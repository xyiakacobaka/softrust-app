using MediatR;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Queries.GetContactByIdQuery
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Contact>
    {
        private readonly MessageFormApiDbContext _context;

        public GetContactByIdQueryHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts.FindAsync(request.Id, cancellationToken);

            if (contact == null)
            {
                throw new Exception("Contact not found");
            }

            return contact;
        }
    }
}
