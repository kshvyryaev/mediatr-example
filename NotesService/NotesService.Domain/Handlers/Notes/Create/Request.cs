using MediatR;

namespace NotesService.Domain.Handlers.Notes.Create
{
	public class Request : IRequest<Response>
	{
		public string Name { get; set; }

		public string Description { get; set; }
	}
}
