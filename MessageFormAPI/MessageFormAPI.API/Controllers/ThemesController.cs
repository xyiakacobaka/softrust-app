using MediatR;
using Microsoft.AspNetCore.Mvc;
using MessageFormApi.Application.Features.Themes.Queries.GetAllThemesQuery;
using MessageFormApi.Domain.Models;
using MessageFormApi.Application.Features.Themes.Commands.CreateThemeCommand;

namespace MessageFormAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ThemesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Themes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theme>>> GetThemes()
        {
            var query = new GetAllThemesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST: api/Themes
        [HttpPost]
        public async Task<ActionResult<Theme>> PostTheme(CreateThemeCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetThemes), new { id = result.Id }, result);
        }
    }
}