using RabbitMQ.Configure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Runner.Messaging {
	/// <summary>
	/// Handles messages from the Broadcast queue.
	/// This queue is used for fanout exchange messages, meaning all consumers receive the same message.
	/// </summary>
	public class QueuBroudcastHandler : IMessageHandler {

		/// <summary>
		/// Processes a message received from the Broadcast queue.
		/// </summary>
		/// <param name="message">The message content to be processed.</param>
		/// <returns>A completed task once processing is finished.</returns>
		public Task HandleMessageAsync(string message) {
			if (string.IsNullOrWhiteSpace(message)) {
				Console.WriteLine("⚠️ Received an empty or null message in QueuBroudcastHandler.");
				return Task.CompletedTask;
			}

			Console.WriteLine($"✅ Processing QueuBroudcastHandler message: {message}");

			return Task.CompletedTask;
		}
	}
}