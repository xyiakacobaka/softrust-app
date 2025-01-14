using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Themes.Commands.DeleteThemeCommand
{
    public class DeleteThemeCommandHandler : IRequestHandler<DeleteThemeCommand, DeleteResultDto>
    {
        private readonly MessageFormApiDbContext _context;

        public DeleteThemeCommandHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteResultDto> Handle(DeleteThemeCommand request, CancellationToken cancellationToken)
        {
            var theme = await _context.Themes
                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (theme == null)
            {
                return new DeleteResultDto
                {
                    IsSuccess = false,
                    Message = "Theme not found."
                };
            }

            _context.Themes.Remove(theme);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteResultDto
            {
                IsSuccess = true,
                Message = "Theme deleted successfully."
            };
        }
    }
}
