using MediatR;
using Microsoft.AspNetCore.Mvc;
using MessageFormApi.Application.Features.Themes.Queries.GetAllThemesQuery;
using MessageFormApi.Domain.Models;
using MessageFormApi.Application.Features.Themes.Commands.CreateThemeCommand;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Application.Features.Themes.Queries.GetThemeByIdQuery;
using MessageFormApi.Application.Features.Themes.Commands.UpdateThemeCommand;
using MessageFormApi.Application.Features.Themes.Commands.DeleteThemeCommand;
using MessageFormApi.Application.Features.Themes.Commands.DeleteAllThemesCommand;

namespace MessageFormAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThemesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ThemesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThemeDto>>> GetAll()
        {
            var query = new GetAllThemesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThemeDto>> GetById(int id)
        {
            var query = new GetThemeByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ThemeDto>> Create(CreateThemeCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ThemeDto>> Update(int id, UpdateThemeCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID in the route does not match ID in the request body.");

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound("Theme not found.");

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteResultDto>> DeleteById(int id)
        {
            var command = new DeleteThemeCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpDelete("all")]
        public async Task<ActionResult<DeleteResultDto>> DeleteAll()
        {
            var command = new DeleteAllThemesCommand();
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result);
        }
    }
}