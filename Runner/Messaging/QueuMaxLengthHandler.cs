using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Max-Length queue.
	/// This queue has a maximum number of messages allowed before older messages are dropped.
	/// </summary>
	public class QueuMaxLengthHandler : IMessageHandler {
		/// <inheritdoc/>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("Received an empty or null message QueuMaxLengthHandler.");
				return Task.CompletedTask;
			}

			Console.WriteLine($"QueuMaxLengthHandler process message: {message}");

			return Task.CompletedTask;
		}
	}
}
