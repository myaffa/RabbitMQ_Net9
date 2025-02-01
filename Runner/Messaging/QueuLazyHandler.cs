using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Lazy queue.
	/// This queue stores messages on disk instead of RAM to optimize memory usage.
	/// </summary>
	public class QueuLazyHandler : IMessageHandler {
		/// <inheritdoc/>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("Received an empty or null message.");
				return Task.CompletedTask;
			}

			Console.WriteLine($"QueuLazyHandler process message: {message}");

			return Task.CompletedTask;
		}
	}
}
