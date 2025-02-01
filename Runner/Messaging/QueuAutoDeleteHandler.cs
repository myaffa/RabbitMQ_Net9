using RabbitMQ.Configure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Auto-Delete queue.
	/// This queue is automatically deleted when no consumers remain.
	/// </summary>
	public class QueuAutoDeleteHandler : IMessageHandler {
		/// <summary>
		/// Processes a message received from the Auto-Delete queue.
		/// </summary>
		/// <param name="message">The message content to be processed.</param>
		/// <returns>A completed task once processing is finished.</returns>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("⚠️ Received an empty or null message in QueuAutoDeleteHandler.");
				return Task.CompletedTask;
			}

			Console.WriteLine($"✅ QueuAutoDeleteHandler successfully processed message: {message}");

			return Task.CompletedTask;
		}
	}
}
