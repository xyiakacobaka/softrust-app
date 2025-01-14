using AutoMapper;
using MediatR;
using MessageFormApi.Application.Features.DTOs;
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
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, PagedResponse<ContactDto>>
    {
        private readonly MessageFormApiDbContext _context;
        private readonly IMapper _mapper;

        public GetAllContactsQueryHandler(MessageFormApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResponse<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await _context.Contacts.CountAsync(cancellationToken);

            var contacts = await _context.Contacts
                .OrderBy(c => c.Id)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var data = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            return new PagedResponse<ContactDto>
            {
                Data = data,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = totalCount
            };
        }
    }
}
