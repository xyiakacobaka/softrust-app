using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageFormApi.Application.Features.Contacts.Commands.CreateContactCommand;
using MessageFormApi.Application.Features.Contacts.Commands.DeleteContactCommand;
using MessageFormApi.Application.Features.Contacts.Commands.UpdateContactCommand;
using MessageFormApi.Application.Features.Contacts.Queries.GetAllContactsQuery;
using MessageFormApi.Application.Features.Contacts.Queries.GetContactByIdQuery;
using MessageFormApi.Domain.Models;

namespace MessageFormAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var query = new GetAllContactsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var query = new GetContactByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(CreateContactCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetContact), new { id = result.Id }, result);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, UpdateContactCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var command = new DeleteContactCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}