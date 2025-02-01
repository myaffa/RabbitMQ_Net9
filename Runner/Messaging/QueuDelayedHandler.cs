using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Delayed queue.
	/// This queue delivers messages with a delay before processing.
	/// </summary>
	public class QueuDelayedHandler : IMessageHandler {
		/// <summary>
		/// Processes a message received from the Delayed queue.
		/// </summary>
		/// <param name="message">The message content to be processed.</param>
		/// <returns>A completed task once processing is finished.</returns>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("⚠️ Received an empty or null message in QueuDelayedHandler.");
				return Task.CompletedTask;
			}

			Console.WriteLine($"✅ Processing QueuDelayedHandler message: {message}");

			return Task.CompletedTask;
		}
	}
}
