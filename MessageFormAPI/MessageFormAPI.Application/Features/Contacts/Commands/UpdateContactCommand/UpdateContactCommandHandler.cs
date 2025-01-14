using AutoMapper;
using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            // Проверка email с помощью регулярного выражения
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!emailRegex.IsMatch(request.Email))
            {
                throw new ValidationException("Invalid email format.");
            }

            // Проверка номера телефона с помощью регулярного выражения
            var phoneRegex = new Regex(@"^8\d{10}$");
            if (!phoneRegex.IsMatch(request.PhoneNumber))
            {
                throw new ValidationException("Invalid phone number format.");
            }

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
