using System;

namespace NotesService.Domain.Handlers.Notes
{
	public class Response
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime? LastUpdateDate { get; set; }
	}
}
