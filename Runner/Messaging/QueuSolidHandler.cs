using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Solid queue.
	/// This queue is durable and ensures message persistence across broker restarts.
	/// </summary>
	public class QueuSolidHandler : IMessageHandler {
		/// <summary>
		/// Processes a message received from the Solid queue.
		/// This queue ensures that messages are not lost during server restarts.
		/// </summary>
		/// <param name="message">The message content to be processed.</param>
		/// <returns>A completed task once processing is finished.</returns>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("⚠️ Received an empty or null message in QueuSolidHandler.");
				return Task.CompletedTask;
			}
			Console.WriteLine($"✅ Processing QueuSolidHandler message: {message}");
			return Task.CompletedTask;
		}
	}
}
