using RabbitMQ.Configure.Interfaces;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the TTL (Time-To-Live) queue.
	/// This queue holds messages for a specified duration before they expire.
	/// </summary>
	public class QueuTTLHandler : IMessageHandler {
		/// <summary>
		/// Processes a message received from the TTL queue.
		/// Messages in this queue have a predefined lifespan and are discarded after expiration.
		/// </summary>
		/// <param name="message">The message content to be processed.</param>
		/// <returns>A completed task once processing is finished.</returns>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("⚠️ Received an empty or null message in QueuTTLHandler.");
				return Task.CompletedTask;
			}
			Console.WriteLine($"✅ Processing QueuTTLHandler message: {message}");
			return Task.CompletedTask;
		}
	}
}
