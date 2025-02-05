namespace RabbitMQ.Configure.Interfaces {
	/// <summary>
	/// Defines a factory interface for creating message handlers based on a given routing key.
	/// Implementations of this factory are responsible for returning the appropriate 
	/// <see cref="IMessageHandler"/> instance based on the provided routing key.
	/// </summary>
	public interface IMessageHandlerFactory {
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
		IMessageHandler? GetHandler(string routingKey);
	}
}
