using MediatR;
using MessageFormApi.Application.Features.Messages.Commands.CreateMessageCommand;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Application.Features.Messages.Queries.GetAllMessagesQuery;
using MessageFormApi.Application.Features.Messages.Queries.GetMessageByIdQuery;
using MessageFormApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageFormApi.Application.Features.Messages.Queries.GetMessagesByContactIdQuery;
using MessageFormApi.Application.Features.Messages.Queries.GetMessagesByThemeIdQuery;

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
            return CreatedAtAction(nameof(GetMessageById), new { id = result.Id }, result);
        }
        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<MessageDto>> GetMessages() 
        {
            var query = new GetAllMessagesQuery { };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> GetMessageById(int id)
        {
            var query = new GetMessageByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        // GET: api/Messages/by-contact/2
        [HttpGet("by-contact/{contactId}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesByContactId(int contactId)
        {
            var query = new GetMessagesByContactIdQuery { ContactId = contactId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        // GET: api/Messages/by-theme/2
        [HttpGet("by-theme/{themeId}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesByThemeId(int themeId)
        {
            var query = new GetMessagesByThemeIdQuery { ThemeId = themeId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
