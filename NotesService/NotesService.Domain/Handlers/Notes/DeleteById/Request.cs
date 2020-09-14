using MediatR;

namespace NotesService.Domain.Handlers.Notes.DeleteById
{
	public class Request : IRequest<Response>
	{
		public int Id { get; set; }
	}
}
