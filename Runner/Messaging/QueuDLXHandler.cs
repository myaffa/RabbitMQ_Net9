using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Dead-Letter queue (DLX).
	/// This queue stores undelivered or rejected messages for further processing.
	/// </summary>
	public class QueuDLXHandler : IMessageHandler {
		/// <summary>
		/// Processes a message received from the Dead-Letter queue.
		/// </summary>
		/// <param name="message">The message content to be processed.</param>
		/// <returns>A completed task once processing is finished.</returns>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("⚠️ Received an empty or null message in QueuDLXHandler.");
				return Task.CompletedTask;
			}

			Console.WriteLine($"✅ Processing QueuDLXHandler message: {message}");

			return Task.CompletedTask;
		}
	}
}
