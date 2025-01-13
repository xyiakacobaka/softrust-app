using MediatR;
using MessageFormApi.Application.Features.Messages.Commands;
using MessageFormApi.Application.Features.Messages.Commands.CreateMessageCommand;
using MessageFormApi.Application.Features.Messages.Queries;
using MessageFormApi.Application.Features.Messages.Queries.GetAllMessagesQuery;
using MessageFormApi.Application.Features.Messages.Queries.GetMessageByIdQuery;
using MessageFormApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageFormApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/Messages
        [HttpPost]
        public async Task<ActionResult<MessageDto>> PostMessage(CreateMessageCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMessage), new { id = result.Id }, result);
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> GetMessage(int id)
        {
            var query = new GetMessageByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
