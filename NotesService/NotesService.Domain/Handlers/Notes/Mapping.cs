using AutoMapper;
using NotesService.Domain.Entities;

namespace NotesService.Domain.Handlers.Notes
{
	public class Mapping : Profile
	{
		public Mapping()
		{
			CreateMap<Note, Response>();
		}
	}
}
