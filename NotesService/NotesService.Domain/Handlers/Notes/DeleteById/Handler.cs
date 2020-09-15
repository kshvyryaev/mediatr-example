using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotesService.Domain.Contracts.Repositories;
using NotesService.Domain.Exeptions;

namespace NotesService.Domain.Handlers.Notes.DeleteById
{
	public class Handler : IRequestHandler<Request, Response>
	{
		private readonly INotesRepository _notesRepository;

		public Handler(INotesRepository notesRepository)
		{
			_notesRepository = notesRepository;
		}

		public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				NotValidExeption.ThrowCannotBeNull(nameof(Request));
			}

			var deleted = await _notesRepository.DeleteByIdAsync(request.Id);
			var response = new Response { Deleted = deleted };

			return response;
		}
	}
}
