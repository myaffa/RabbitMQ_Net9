using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Exclusive queue.
	/// This queue is only accessible by the connection that created it and is deleted when the connection closes.
	/// </summary>
	public class QueuExclusiveHandler : IMessageHandler {
		/// <summary>
		/// Processes a message received from the Exclusive queue.
		/// </summary>
		/// <param name="message">The message content to be processed.</param>
		/// <returns>A completed task once processing is finished.</returns>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("⚠️ Received an empty or null message in QueuExclusiveHandler.");
				return Task.CompletedTask;
			}

			Console.WriteLine($"✅ Processing QueuExclusiveHandler message: {message}");

			return Task.CompletedTask;
		}
	}
}
