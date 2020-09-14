using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesService.Domain.Contracts.Repositories;
using NotesService.Infrastructure.Data;
using NotesService.Infrastructure.Data.Repositories;

namespace NotesService.Infrastructure
{
	public static class Setup
	{
		private const string DatabaseSectionName = "Database";

		public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseSectionName));
			services.AddSingleton<INotesRepository, NotesRepository>();

			return services;
		}
	}
}
