using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Configure.Enums;
using RabbitMQ.Configure.Interfaces;
using RabbitMQ.Configure.Services;

namespace RabbitMQ.Configure.Configuration {
	/// <summary>
	/// Provides configuration methods for setting up RabbitMQ services, including 
	/// connections, message handling, and queue-exchange bindings.
	/// </summary>
	public static class RabbitMqConfiguration {
		/// <summary>
		/// Configures RabbitMQ settings and registers necessary services in the dependency injection container.
		/// </summary>
		/// <param name="services">The service collection to which RabbitMQ services will be added.</param>
		/// <returns>The updated <see cref="IServiceCollection"/> with RabbitMQ configurations.</returns>
		public static async Task<IServiceCollection> ConfigureRabbitMq(this IServiceCollection services) {
			if (services == null) throw new ArgumentNullException(nameof(services), "Service collection cannot be null.");

			// Load RabbitMQ configuration from appsettings file
			var configuration = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("Configuration/appsettings.rabbitmq.json", optional: false, reloadOnChange: true)
				.Build();

			var rabbitSettings = configuration.GetSection("rabbitmq");
			ValidateRabbitMqSettings(rabbitSettings);

			// Establish RabbitMQ connection
			await services.GenerateConnection(rabbitSettings);

			// Register required RabbitMQ services
			services.RegisterServices();

			return services;
		}

		/// <summary>
		/// Generates a RabbitMQ connection using the provided configuration settings.
		/// </summary>
		/// <param name="services">The service collection where the connection will be registered.</param>
		/// <param name="rabbitSettings">The RabbitMQ configuration settings.</param>
		/// <returns>The updated <see cref="IServiceCollection"/> with the RabbitMQ connection.</returns>
		private static async Task<IServiceCollection> GenerateConnection(this IServiceCollection services, IConfigurationSection rabbitSettings) {
			// Create connection factory with provided settings
			ConnectionFactory factory = new() {
				UserName = rabbitSettings["username"] ?? "admin",
				Password = rabbitSettings["password"] ?? "password",
				NetworkRecoveryInterval = TimeSpan.FromSeconds(int.TryParse(rabbitSettings["network_recovery_interval"], out int interval) ? interval : 1),
				HostName = rabbitSettings["host"] ?? "localhost",
				Port = int.TryParse(rabbitSettings["port"], out int port) ? port : 5672
			};

			// Establish connection asynchronously
			IConnection connection = await factory.CreateConnectionAsync();
			services.AddSingleton(connection);

			Console.WriteLine("✅ RabbitMQ connection established successfully.");

			// Configure RabbitMQ queues and exchanges
			await services.ConfigureQueuesAndExchanges(connection, int.TryParse(rabbitSettings["ttl_for_broadcast"], out int ttl) ? ttl : 120000);

			return services;
		}

		/// <summary>
		/// Validates the necessary RabbitMQ settings before establishing a connection.
		/// </summary>
		/// <param name="rabbitSettings">The RabbitMQ configuration section.</param>
		/// <exception cref="ArgumentException">Throws exception if required settings are missing or invalid.</exception>
		private static void ValidateRabbitMqSettings(IConfigurationSection rabbitSettings) {
			if (string.IsNullOrWhiteSpace(rabbitSettings["host"]))
				throw new ArgumentException("RabbitMQ host is missing in configuration.");

			if (!int.TryParse(rabbitSettings["port"], out _))
				throw new ArgumentException("RabbitMQ port is invalid.");
		}

		/// <summary>
		/// Registers RabbitMQ-related services such as message handling and processing.
		/// </summary>
		/// <param name="services">The service collection where services will be registered.</param>
		/// <returns>The updated <see cref="IServiceCollection"/> with RabbitMQ services.</returns>
		private static IServiceCollection RegisterServices(this IServiceCollection services) {
			services.AddScoped<IMessageHandlerFactory, MessageHandlerFactory>();
			services.AddScoped<IMessageProcessor, MessageProcessor>();
			services.AddSingleton<IRabbitMQListener, RabbitMQListener>();
			services.AddSingleton<IRabbitMQSender, RabbitMQSender>();
			return services;
		}
	}
}
