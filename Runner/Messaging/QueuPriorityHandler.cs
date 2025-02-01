using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Priority queue.
	/// Messages are processed based on priority level.
	/// </summary>
	public class QueuPriorityHandler : IMessageHandler {
		/// <inheritdoc/>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("Received an empty or null message QueuPriorityHandler.");
				return Task.CompletedTask;
			}

			Console.WriteLine($"QueuPriorityHandler process message: {message}");

			return Task.CompletedTask;
		}
	}
}
