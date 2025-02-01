namespace RabbitMQ.Configure.Interfaces {
	/// <summary>
	/// Defines the contract for listening to RabbitMQ queues and maintaining a persistent connection.
	/// Implementing classes should ensure the connection remains active and handle incoming messages.
	/// </summary>
	public interface IRabbitMQListener {
		/// <summary>
		/// Ensures that the connection to RabbitMQ remains active and starts listening for incoming messages.
		/// This method should handle reconnections in case of failures.
		/// </summary>
		/// <param name="cancellationToken">
		/// A <see cref="CancellationToken"/> to observe for connection retries and to allow graceful shutdown.
		/// </param>
		/// <returns>
		/// A <see cref="Task"/> representing the asynchronous operation of maintaining the connection.
		/// </returns>
		/// <exception cref="OperationCanceledException">
		/// Thrown if the operation is canceled via the <paramref name="cancellationToken"/>.
		/// </exception>
		Task EnsureConnectionAsync(CancellationToken cancellationToken);
	}
}
