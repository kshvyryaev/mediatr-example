using System;
using System.Net;
using System.Net.Http;
using Polly;
using Polly.Extensions.Http;

namespace NotesService.Infrastructure.HttpClients
{
	public static class HttpPolicies
	{
		public static IAsyncPolicy<HttpResponseMessage> CircuitBreaker
			=> HttpPolicyExtensions.HandleTransientHttpError().CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));

		public static IAsyncPolicy<HttpResponseMessage> Retry
			=> HttpPolicyExtensions.HandleTransientHttpError()
				.OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
				.WaitAndRetryAsync(5, retryAttempy => TimeSpan.FromSeconds(Math.Pow(2, retryAttempy)));
	}
}
