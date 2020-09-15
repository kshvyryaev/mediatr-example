using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NotesService.Domain.Contracts.Repositories;
using NotesService.Domain.Entities;
using NotesService.Domain.Exeptions;

namespace NotesService.Domain.Handlers.Notes.GetById
{
	public class Handler : IRequestHandler<Request, Response>
	{
		private readonly IMapper _mapper;
		private readonly INotesRepository _notesRepository;

		public Handler(
			IMapper mapper,
			INotesRepository notesRepository)
		{
			_mapper = mapper;
			_notesRepository = notesRepository;
		}

		public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				NotValidExeption.ThrowCannotBeNull(nameof(Request));
			}

			var note = await _notesRepository.GetByIdAsync(request.Id);
			if (note == null)
			{
				NotFoundExeption.ThrowWithId(nameof(Note), request.Id);
			}

			var response = _mapper.Map<Response>(note);

			return response;
		}
	}
}
