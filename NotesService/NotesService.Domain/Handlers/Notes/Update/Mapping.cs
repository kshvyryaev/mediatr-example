using System;
using AutoMapper;
using NotesService.Domain.Entities;

namespace NotesService.Domain.Handlers.Notes.Update
{
	public class Mapping : Profile
	{
		public Mapping()
		{
			CreateMap<Request, Note>()
				.ForMember(dest => dest.CreationDate, opt => opt.Ignore())
				.ForMember(dest => dest.LastUpdateDate, opt => opt.MapFrom(x => DateTime.UtcNow));
		}
	}
}
