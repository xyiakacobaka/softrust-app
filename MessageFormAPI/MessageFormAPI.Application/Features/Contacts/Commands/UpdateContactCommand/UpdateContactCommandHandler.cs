using AutoMapper;
using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Commands.UpdateContactCommand
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ContactDto>
    {
        private readonly MessageFormApiDbContext _context;
        private readonly IMapper _mapper;

        public UpdateContactCommandHandler(MessageFormApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactDto> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (contact == null)
                return null;

            contact.UserName = request.UserName;
            contact.Email = request.Email;
            contact.PhoneNumber = request.PhoneNumber;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ContactDto>(contact);
        }
    }
}
