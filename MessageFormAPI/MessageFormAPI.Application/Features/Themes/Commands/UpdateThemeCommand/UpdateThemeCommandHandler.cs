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

namespace MessageFormApi.Application.Features.Themes.Commands.UpdateThemeCommand
{
    public class UpdateThemeCommandHandler : IRequestHandler<UpdateThemeCommand, ThemeDto>
    {
        private readonly MessageFormApiDbContext _context;
        private readonly IMapper _mapper;

        public UpdateThemeCommandHandler(MessageFormApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ThemeDto> Handle(UpdateThemeCommand request, CancellationToken cancellationToken)
        {
            var theme = await _context.Themes
                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (theme == null)
                return null;

            theme.ThemeLabel = request.ThemeLabel;
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ThemeDto>(theme);
        }
    }
}
