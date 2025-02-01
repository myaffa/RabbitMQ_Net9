using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Deduplication queue.
	/// This queue ensures that duplicate messages are not processed.
	/// </summary>
	public class QueuDeduplicationHandler : IMessageHandler {
		/// <summary>
		/// Processes a message received from the Deduplication queue.
		/// </summary>
		/// <param name="message">The message content to be processed.</param>
		/// <returns>A completed task once processing is finished.</returns>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("⚠️ Received an empty or null message in QueuDeduplicationHandler.");
				return Task.CompletedTask;
			}

			Console.WriteLine($"✅ Processing QueuDeduplicationHandler message: {message}");

			return Task.CompletedTask;
		}
	}
}
