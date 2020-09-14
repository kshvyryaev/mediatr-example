using System;
using AutoMapper;
using NotesService.Domain.Entities;

namespace NotesService.Domain.Handlers.Notes.Create
{
	public class Mapping : Profile
	{
		public Mapping()
		{
			CreateMap<Request, Note>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.CreationDate, opt => opt.MapFrom(x => DateTime.UtcNow))
				.ForMember(dest => dest.LastUpdateDate, opt => opt.Ignore());
		}
	}
}
