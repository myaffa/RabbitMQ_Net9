using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using RabbitMQ.Configure.Interfaces;
using System.Text;
using RabbitMQ.Configure.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace RabbitMQ.Configure.Services {
	/// <summary>
	/// Service responsible for listening to RabbitMQ queues and processing incoming messages.
	/// This service maintains an active connection and listens for messages asynchronously.
	/// Initializes a new instance of the <see cref="RabbitMQListener"/> class.
	/// </summary>
	/// <param name="connection">The RabbitMQ connection instance.</param>
	/// <param name="channel">The RabbitMQ channel for consuming messages.</param>
	/// <param name="serviceProvider">The service provider for dependency injection.</param>
	public class RabbitMQListener(IConnection connection, IChannel channel, IServiceProvider serviceProvider) : IRabbitMQListener {
		private readonly IChannel _channel = channel ?? throw new ArgumentNullException(nameof(channel), "RabbitMQ channel cannot be null.");
		private readonly IServiceProvider _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider), "Service provider cannot be null.");
		private readonly IConnection _connection = connection ?? throw new ArgumentNullException(nameof(connection), "RabbitMQ connection cannot be null.");

		/// <summary>
		/// Ensures the RabbitMQ connection is active and starts listening for incoming messages.
		/// </summary>
		/// <param name="cancellationToken">
		/// A <see cref="CancellationToken"/> to handle graceful shutdown.
		/// </param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task EnsureConnectionAsync(CancellationToken cancellationToken) {
			if (_connection.IsOpen) {
				Console.WriteLine("✅ RabbitMQ connection is open. Starting to listen...");
				await StartListeningAsync();
			} else {
				Console.WriteLine("⚠️ RabbitMQ connection is closed. Reconnection logic is not required due to automatic recovery.");
			}
		}

		/// <summary>
		/// Starts listening to RabbitMQ queues and processes incoming messages asynchronously.
		/// </summary>
		private async Task StartListeningAsync() {
			if (!_channel.IsOpen) {
				Console.WriteLine("⚠️ RabbitMQ channel is not open. Cannot start listening.");
				return;
			}

			var consumer = new AsyncEventingBasicConsumer(_channel);
			consumer.ReceivedAsync += async (model, ea) => {
				var message = Encoding.UTF8.GetString(ea.Body.ToArray());
				var routingKey = ea.RoutingKey;

				try {
					// Process the message asynchronously using a scoped dependency
					using var scope = _serviceProvider.CreateScope();
					var messageProcessor = scope.ServiceProvider.GetRequiredService<IMessageProcessor>();
					await messageProcessor.ProcessMessageAsync(routingKey, message);

					// Acknowledge successful processing
					await _channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
				} catch (Exception ex) {
					Console.WriteLine($"❌ Error processing message: {ex.Message}");

					// Negative acknowledgment (NACK) with requeue option
					await _channel.BasicNackAsync(ea.DeliveryTag, multiple: false, requeue: true);
				}
			};

			// Subscribe to all queues defined in the enumeration
			foreach (var queue in Enum.GetNames<EnRabbitMQQueue>()) {
				await _channel.BasicConsumeAsync(queue, autoAck: false, consumer);
				Console.WriteLine($"🎧 Listening to queue: {queue}");
			}
		}
	}
}
