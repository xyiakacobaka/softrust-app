using AutoMapper;
using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MessageFormApi.Application.Features.Contacts.Commands.CreateContactCommand
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactDto>
    {
        private readonly MessageFormApiDbContext _context;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(MessageFormApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
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

            // Проверка на существование контакта с таким же Email и PhoneNumber
            var existingContact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.Email == request.Email && c.PhoneNumber == request.PhoneNumber, cancellationToken);

            if (existingContact != null)
            {
                return _mapper.Map<ContactDto>(existingContact);
            }

            // Создание нового контакта
            var contact = new Contact
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ContactDto>(contact);
        }
    }
}
