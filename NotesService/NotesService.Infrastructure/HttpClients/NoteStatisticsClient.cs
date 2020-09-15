using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NotesService.Domain.Contracts.HttpClients;
using NotesService.Domain.Entities;

namespace NotesService.Infrastructure.HttpClients
{
	// TODO: Implement note statistics client
	public class NoteStatisticsClient : INoteStatisticsClient
	{
		private readonly HttpClient _httpClient;
		private readonly NoteStatisticsOptions _options;

		public NoteStatisticsClient(HttpClient httpClient, IOptions<NoteStatisticsOptions> options)
		{
			_httpClient = httpClient;
			_options = options.Value;
		}

		public Task<NoteStatistic> GetByNoteId(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
