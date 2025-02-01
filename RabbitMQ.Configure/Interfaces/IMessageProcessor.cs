namespace RabbitMQ.Configure.Interfaces {
	/// <summary>
	/// Defines the contract for processing messages received from RabbitMQ queues.
	/// Implementing classes should handle message processing based on a routing key.
	/// </summary>
	public interface IMessageProcessor {
		/// <summary>
		/// Asynchronously processes a message associated with a specific routing key.
		/// </summary>
		/// <param name="routingKey">
		/// The routing key used to identify the type of the message.
		/// </param>
		/// <param name="message">
		/// The content of the message that needs to be processed.
		/// </param>
		/// <returns>
		/// A <see cref="Task"/> representing the asynchronous operation.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown when <paramref name="routingKey"/> or <paramref name="message"/> is null or empty.
		/// </exception>
		Task ProcessMessageAsync(string routingKey, string message);
	}
}
