using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Quorum queue.
	/// This is a highly available, replicated queue used in clustered environments.
	/// </summary>
	public class QueuQuorumHandler : IMessageHandler {
		/// <inheritdoc/>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("Received an empty or null message QueuQuorumHandler.");
				return Task.CompletedTask;
			}

			Console.WriteLine($"QueuQuorumHandler process message: {message}");

			return Task.CompletedTask;
		}
	}
}
