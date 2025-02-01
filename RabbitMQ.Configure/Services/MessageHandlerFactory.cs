using RabbitMQ.Configure.Interfaces;

namespace RabbitMQ.Configure.Services {
	/// <summary>
	/// Factory class responsible for providing message handlers based on routing keys.
	/// This factory maintains a dictionary of registered message handlers and 
	/// returns the appropriate handler for a given routing key.
	/// </summary>
	public class MessageHandlerFactory : IMessageHandlerFactory {
		private readonly Dictionary<string, IMessageHandler> _handlers;

		/// <summary>
		/// Initializes a new instance of the <see cref="MessageHandlerFactory"/> class.
		/// </summary>
		/// <param name="handlers">
		/// A collection of message handlers to register in the factory.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if <paramref name="handlers"/> is null.
		/// </exception>
		public MessageHandlerFactory(IEnumerable<IMessageHandler> handlers) {
			if (handlers == null)
				throw new ArgumentNullException(nameof(handlers), "Handlers collection cannot be null.");

			_handlers = new Dictionary<string, IMessageHandler>(StringComparer.OrdinalIgnoreCase);

			foreach (var handler in handlers) {
				if (handler == null) continue;
				var key = handler.GetType().Name.Replace("Handler", ""); // Extracts routing key from class name
				_handlers[key] = handler;
			}
		}

		/// <summary>
		/// Retrieves the appropriate message handler for the specified routing key.
		/// </summary>
		/// <param name="routingKey">
		/// The routing key used to determine the corresponding message handler.
		/// </param>
		/// <returns>
		/// An instance of <see cref="IMessageHandler"/> capable of processing messages 
		/// for the specified routing key.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if <paramref name="routingKey"/> is null or empty.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no handler is found for the specified routing key.
		/// </exception>
		public IMessageHandler GetHandler(string routingKey) {
			if (string.IsNullOrWhiteSpace(routingKey))
				throw new ArgumentNullException(nameof(routingKey), "Routing key cannot be null or empty.");

			return _handlers.TryGetValue(routingKey, out var handler)
				? handler
				: throw new InvalidOperationException($"No handler found for routing key: {routingKey}");
		}
	}
}
