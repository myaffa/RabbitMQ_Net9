using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Configure.Enums;
using RabbitMQ.Configure.Interfaces;
using System.Text;

namespace RabbitMQ.Configure.Services {
	/// <summary>
	/// Service responsible for sending messages to RabbitMQ queues.
	/// Initializes a new instance of the <see cref="RabbitMQSender"/> class.
	/// </summary>
	/// <param name="connection">
	/// The RabbitMQ connection used for sending messages.
	/// </param>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="connection"/> is null.
	/// </exception>
	public class RabbitMQSender(IConnection connection) : IRabbitMQSender {
		private readonly IConnection _connection=connection ?? throw new ArgumentNullException(nameof(connection), "RabbitMQ connection cannot be null.");

		/// <inheritdoc/>
		public async Task SendToQueue(EnRabbitMQQueue queueName, string loginKey, string data) {
			// Validate input parameters
			if (string.IsNullOrWhiteSpace(loginKey))
				throw new ArgumentNullException(nameof(loginKey), "Login key cannot be null or empty.");

			if (string.IsNullOrWhiteSpace(data))
				throw new ArgumentNullException(nameof(data), "Data to send cannot be null or empty.");

			try {
				using var channel = await _connection.CreateChannelAsync();
				var body = Encoding.UTF8.GetBytes(data);

				// Publish message to the specified queue
				await channel.BasicPublishAsync(
					exchange: "",
					routingKey: queueName.ToString(),
					mandatory: false,
					body: new ReadOnlyMemory<byte>(body));

				Console.WriteLine($"✅ Message successfully sent to queue: {queueName}");
			} catch (AlreadyClosedException ex) {
				Console.WriteLine($"❌ RabbitMQ connection is closed: {ex.Message}");
				throw;
			} catch (Exception ex) {
				Console.WriteLine($"❌ Failed to send message to RabbitMQ queue '{queueName}': {ex.Message}");
				throw;
			}
		}
	}
}
