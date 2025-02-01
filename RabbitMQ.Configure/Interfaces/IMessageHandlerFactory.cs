namespace RabbitMQ.Configure.Interfaces {
	/// <summary>
	/// Defines a factory interface for creating message handlers based on a given routing key.
	/// Implementations of this factory are responsible for returning the appropriate 
	/// <see cref="IMessageHandler"/> instance based on the provided routing key.
	/// </summary>
	public interface IMessageHandlerFactory {
		/// <summary>
		/// Retrieves the appropriate message handler based on the specified routing key.
		/// </summary>
		/// <param name="routingKey">
		/// The routing key used to determine the appropriate message handler.
		/// </param>
		/// <returns>
		/// An instance of <see cref="IMessageHandler"/> capable of processing messages 
		/// associated with the specified routing key, or <c>null</c> if no suitable handler is found.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown when the <paramref name="routingKey"/> is null or empty.
		/// </exception>
		IMessageHandler? GetHandler(string routingKey);
	}
}
