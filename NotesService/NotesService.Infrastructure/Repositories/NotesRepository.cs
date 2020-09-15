using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NotesService.Domain.Contracts.Repositories;
using NotesService.Domain.Entities;

namespace NotesService.Infrastructure.Repositories
{
	// TODO: Implement repository
	public class NotesRepository : INotesRepository
	{
		private readonly DatabaseOptions _options;

		public NotesRepository(IOptions<DatabaseOptions> options)
		{
			_options = options.Value;
		}

		public Task<Note> CreateAsync(Note note)
		{
			throw new System.NotImplementedException();
		}

		public Task<Note> GetByIdAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<Note> UpdateAsync(Note note)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> DeleteByIdAsync(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
