using MediatR;
using MessageFormApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Queries.GetAllContactsQuery
{
    public class GetAllContactsQuery : IRequest<IEnumerable<Contact>>
    {
    }
}
