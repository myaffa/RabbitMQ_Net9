namespace RabbitMQ.Configure.Interfaces {
	/// <summary>
	/// Defines the contract for processing messages received from RabbitMQ queues.
	/// Implementing classes should handle message processing based on a routing key.
	/// </summary>
	public interface IMessageProcessor {
		/// <summary>
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
		Task ProcessMessageAsync(string routingKey, string message);
	}
}
