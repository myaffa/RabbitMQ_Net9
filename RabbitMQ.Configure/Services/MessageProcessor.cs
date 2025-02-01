using RabbitMQ.Configure.Interfaces;

namespace RabbitMQ.Configure.Services {
	/// <summary>
	/// Service responsible for processing messages received from RabbitMQ queues.
	/// It retrieves the appropriate message handler based on the routing key and processes the message.
	/// Initializes a new instance of the <see cref="MessageProcessor"/> class.
	/// </summary>
	/// <param name="handlerFactory">
	/// The factory responsible for retrieving message handlers based on routing keys.
	/// </param>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="handlerFactory"/> is null.
	/// </exception>
	public class MessageProcessor(IMessageHandlerFactory handlerFactory) : IMessageProcessor {
		private readonly IMessageHandlerFactory _handlerFactory = handlerFactory ?? throw new ArgumentNullException(nameof(handlerFactory), "Handler factory cannot be null.");

		/// <summary>
		/// Asynchronously processes a message using the appropriate handler for the given routing key.
		/// </summary>
		/// <param name="routingKey">
		/// The routing key that determines the appropriate message handler.
		/// </param>
		/// <param name="message">
		/// The message content that needs to be processed.
		/// </param>
		/// <returns>
		/// A <see cref="Task"/> representing the asynchronous message processing operation.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if <paramref name="routingKey"/> or <paramref name="message"/> is null or empty.
		/// </exception>
		public async Task ProcessMessageAsync(string routingKey, string message) {
			if (string.IsNullOrWhiteSpace(routingKey))
				throw new ArgumentNullException(nameof(routingKey), "Routing key cannot be null or empty.");

			if (string.IsNullOrWhiteSpace(message))
				throw new ArgumentNullException(nameof(message), "Message cannot be null or empty.");

			try {
				var handler = _handlerFactory.GetHandler(routingKey);

				if (handler == null) {
					Console.WriteLine($"⚠️ No handler found for routing key: {routingKey}");
					return;
				}

				await handler.HandleMessageAsync(message);
				Console.WriteLine($"✅ Message processed successfully for routing key: {routingKey}");
			} catch (Exception ex) {
				Console.WriteLine($"❌ Error processing message with routing key '{routingKey}': {ex.Message}");
				throw;
			}
		}
	}
}
