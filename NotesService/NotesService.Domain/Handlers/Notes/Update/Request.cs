using MediatR;

namespace NotesService.Domain.Handlers.Notes.Update
{
	public class Request : IRequest<Response>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
