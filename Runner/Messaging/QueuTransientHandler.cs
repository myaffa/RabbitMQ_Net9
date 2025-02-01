using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Transient queue.
	/// This queue is non-durable and will be deleted when the connection is closed.
	/// </summary>
	public class QueuTransientHandler : IMessageHandler {
		/// <summary>
		/// Processes a message received from the Transient queue.
		/// Messages in this queue do not persist across broker restarts.
		/// </summary>
		/// <param name="message">The message content to be processed.</param>
		/// <returns>A completed task once processing is finished.</returns>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("⚠️ Received an empty or null message in QueuTransientHandler.");
				return Task.CompletedTask;
			}
			Console.WriteLine($"✅ Processing QueuTransientHandler message: {message}");
			return Task.CompletedTask;
		}
	}
}
