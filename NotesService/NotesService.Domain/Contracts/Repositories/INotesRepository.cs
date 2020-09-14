using System.Threading.Tasks;
using NotesService.Domain.Entities;

namespace NotesService.Domain.Contracts.Repositories
{
	public interface INotesRepository
	{
		Task<Note> CreateAsync(Note note);

		Task<Note> GetByIdAsync(int id);

		Task<Note> UpdateAsync(Note note);

		Task<bool> DeleteByIdAsync(int id);
	}
}
