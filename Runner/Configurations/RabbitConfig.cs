using RabbitMQ.Configure.Configuration;
using RabbitMQ.Configure.Interfaces;
using Runner.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Runner.Configurations {
	/// <summary>
	/// Provides configuration methods for setting up RabbitMQ in the application.
	/// This class ensures that RabbitMQ services and message handlers are properly registered.
	/// </summary>
	public static class RabbitConfig {
		/// <summary>
		/// Configures RabbitMQ services and registers message handlers.
		/// </summary>
		/// <param name="services">The service collection where RabbitMQ services will be registered.</param>
		/// <returns>
		/// A <see cref="Task"/> representing the asynchronous operation, returning an updated <see cref="IServiceCollection"/>.
		/// </returns>
		public static async Task<IServiceCollection> RabbitConfiguration(this IServiceCollection services) {
			if (services == null)
				throw new ArgumentNullException(nameof(services), "Service collection cannot be null.");

			// Configure RabbitMQ services
			await services.ConfigureRabbitMq();

			// Register all message handlers
			RegisterMessageHandlers(services);

			return services;
		}

		/// <summary>
		/// Registers all available message handlers with the service collection.
		/// Each handler is responsible for processing messages from a specific RabbitMQ queue.
		/// </summary>
		/// <param name="services">The service collection to which handlers will be added.</param>
		private static void RegisterMessageHandlers(IServiceCollection services) {
			services.AddScoped<IMessageHandler, QueuBroudcastHandler>();
			services.AddScoped<IMessageHandler, QueuSolidHandler>();
			services.AddScoped<IMessageHandler, QueuAutoDeleteHandler>();
			services.AddScoped<IMessageHandler, QueuDeduplicationHandler>();
			services.AddScoped<IMessageHandler, QueuDelayedHandler>();
			services.AddScoped<IMessageHandler, QueuDLXHandler>();
			services.AddScoped<IMessageHandler, QueuExclusiveHandler>();
			services.AddScoped<IMessageHandler, QueuLazyHandler>();
			services.AddScoped<IMessageHandler, QueuMaxLengthHandler>();
			services.AddScoped<IMessageHandler, QueuPriorityHandler>();
			services.AddScoped<IMessageHandler, QueuQuorumHandler>();
			services.AddScoped<IMessageHandler, QueuTransientHandler>();
			services.AddScoped<IMessageHandler, QueuTTLHandler>();
		}
	}
}
