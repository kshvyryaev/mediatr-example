using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using FluentValidation.AspNetCore;

namespace NotesService.Domain
{
	public static class Setup
	{
		public static IServiceCollection AddHandlers(this IServiceCollection services)
			=> services.AddMediatR(Assembly.GetExecutingAssembly())
				.AddAutoMapper(Assembly.GetExecutingAssembly());

		public static IMvcBuilder AddHandlersValidation(this IMvcBuilder mvcBuilder)
			=> mvcBuilder.AddFluentValidation(configuration =>
				configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
	}
}
