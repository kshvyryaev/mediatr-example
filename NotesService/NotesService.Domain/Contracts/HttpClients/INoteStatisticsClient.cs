using System.Threading.Tasks;
using NotesService.Domain.Entities;

namespace NotesService.Domain.Contracts.HttpClients
{
	public interface INoteStatisticsClient
	{
		Task<NoteStatistic> GetByNoteId(int id);
	}
}
