using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesService.Domain.Contracts.HttpClients;
using NotesService.Domain.Contracts.Repositories;
using NotesService.Infrastructure.HttpClients;
using NotesService.Infrastructure.Repositories;

namespace NotesService.Infrastructure
{
	public static class Setup
	{
		private const string DatabaseSectionName = "Database";
		private const string NoteStatisticsClientSectionName = "NoteStatisticsClient";

		public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseSectionName));

			services.AddSingleton<INotesRepository, NotesRepository>();

			return services;
		}

		public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<NoteStatisticsOptions>(configuration.GetSection(NoteStatisticsClientSectionName));

			services.AddHttpClient<INoteStatisticsClient, NoteStatisticsClient>()
				.AddPolicyHandler(HttpPolicies.Retry)
				.AddPolicyHandler(HttpPolicies.CircuitBreaker);

			return services;
		}
	}
}
