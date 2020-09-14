using MediatR;

namespace NotesService.Domain.Handlers.Notes.GetById
{
	public class Request : IRequest<Response>
	{
		public int Id { get; set; }
	}
}
