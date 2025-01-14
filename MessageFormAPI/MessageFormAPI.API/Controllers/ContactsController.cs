using MediatR;
using Microsoft.AspNetCore.Mvc;
using MessageFormApi.Application.Features.Contacts.Commands.CreateContactCommand;
using MessageFormApi.Application.Features.Contacts.Commands.DeleteContactCommand;
using MessageFormApi.Application.Features.Contacts.Commands.UpdateContactCommand;
using MessageFormApi.Application.Features.Contacts.Queries.GetAllContactsQuery;
using MessageFormApi.Application.Features.Contacts.Queries.GetContactByIdQuery;
using MessageFormApi.Application.Features.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MessageFormAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<ContactDto>>> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetAllContactsQuery { Page = page, PageSize = pageSize };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> GetById(int id)
        {
            var query = new GetContactByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ContactDto>> Create(CreateContactCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContactDto>> Update(int id, UpdateContactCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var command = new DeleteContactCommand { Id = id };
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}