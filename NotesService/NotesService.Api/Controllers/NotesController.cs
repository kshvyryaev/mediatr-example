using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes = NotesService.Domain.Handlers.Notes;

namespace NotesService.Api.Controllers
{
	[ApiController]
	[Route("notes")]
	public class NotesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public NotesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateAsync([FromBody] Notes.Create.Request request)
		{
			var response = await _mediator.Send(request);
			return CreatedAtAction(nameof(CreateAsync), response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateAsync([FromBody] Notes.Update.Request request)
		{
			var response = await _mediator.Send(request);
			return Ok(response);
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetByIdAsync([FromQuery] Notes.GetById.Request request)
		{
			var response = await _mediator.Send(request);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> DeleteByIdAsync([FromQuery] Notes.DeleteById.Request request)
		{
			var response = await _mediator.Send(request);
			return Ok(response);
		}
	}
}
