namespace RabbitMQ.Configure.Interfaces {
	/// <summary>
	/// Represents an interface for handling messages received from RabbitMQ queues.
	/// Implementing classes should provide logic to process incoming messages asynchronously.
	/// </summary>
	public interface IMessageHandler {
		/// <summary>
		/// Asynchronously processes the given message received from a RabbitMQ queue.
		/// </summary>
		/// <param name="message">The message content to be processed.</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous processing operation.</returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown when the <paramref name="message"/> is null or empty.
		/// </exception>
		Task HandleMessageAsync(string message);
	}
}
