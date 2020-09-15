using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using NotesService.Domain.Contracts.Repositories;
using NotesService.Domain.Entities;
using NotesService.Domain.Exeptions;

namespace NotesService.Domain.Handlers.Notes.Update
{
	public class Handler : IRequestHandler<Request, Response>
	{
		private readonly IValidator<Request> _validator;
		private readonly IMapper _mapper;
		private readonly INotesRepository _notesRepository;

		public Handler(
			IValidator<Request> validator,
			IMapper mapper,
			INotesRepository notesRepository)
		{
			_validator = validator;
			_mapper = mapper;
			_notesRepository = notesRepository;
		}

		public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				NotValidExeption.ThrowCannotBeNull(nameof(Request));
			}

			var validationResult = _validator.Validate(request);
			if (!validationResult.IsValid)
			{
				NotValidExeption.ThrowWithErrors(validationResult.Errors);
			}

			var note = _mapper.Map<Note>(request);
			var updatedNote = await _notesRepository.UpdateAsync(note);
			var response = _mapper.Map<Response>(updatedNote);

			return response;
		}
	}
}
