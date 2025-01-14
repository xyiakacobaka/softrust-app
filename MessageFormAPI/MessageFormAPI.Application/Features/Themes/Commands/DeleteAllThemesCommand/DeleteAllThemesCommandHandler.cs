using MediatR;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Themes.Commands.DeleteAllThemesCommand
{
    public class DeleteAllThemesCommandHandler : IRequestHandler<DeleteAllThemesCommand, DeleteResultDto>
    {
        private readonly MessageFormApiDbContext _context;

        public DeleteAllThemesCommandHandler(MessageFormApiDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteResultDto> Handle(DeleteAllThemesCommand request, CancellationToken cancellationToken)
        {
            var themes = await _context.Themes.ToListAsync(cancellationToken);

            if (themes.Count == 0)
            {
                return new DeleteResultDto
                {
                    IsSuccess = false,
                    Message = "No themes found to delete."
                };
            }

            _context.Themes.RemoveRange(themes);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteResultDto
            {
                IsSuccess = true,
                Message = "All themes deleted successfully."
            };
        }
    }
}
