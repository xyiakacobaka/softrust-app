using MediatR;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Queries.GetAllContactsQuery
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<Contact>>
    {
        private readonly MessageFormApiDbContext _context;

        public GetAllContactsQueryHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contacts.ToListAsync(cancellationToken);
        }
    }
}
