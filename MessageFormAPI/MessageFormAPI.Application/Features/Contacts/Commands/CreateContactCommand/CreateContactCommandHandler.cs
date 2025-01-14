using AutoMapper;
using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Domain.Models;
using MessageFormApi.Infrastructure.Persistence;

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
