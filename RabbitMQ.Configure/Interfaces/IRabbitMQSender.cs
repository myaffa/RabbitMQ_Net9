using RabbitMQ.Client.Exceptions;
using RabbitMQ.Configure.Enums;

namespace RabbitMQ.Configure.Interfaces {
	/// <summary>
	/// Defines the contract for sending messages to RabbitMQ queues.
	/// Implementing classes should handle message transmission to the specified queue.
	/// </summary>
	public interface IRabbitMQSender {
		/// <summary>
		/// Asynchronously sends a message to the specified RabbitMQ queue.
		/// </summary>
		/// <param name="queueName">
		/// The queue to which the message will be sent.
		/// </param>
		/// <param name="loginKey">
		/// The login key associated with the message sender.
		/// </param>
		/// <param name="data">
		/// The content of the message to be sent.
		/// </param>
		/// <returns>
		/// A <see cref="Task"/> representing the asynchronous operation.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if <paramref name="queueName"/>, <paramref name="loginKey"/>, or <paramref name="data"/> is null or empty.
		/// </exception>
		/// <exception cref="AlreadyClosedException">
		/// Thrown if the RabbitMQ connection is already closed.
		/// </exception>
		/// <exception cref="Exception">
		/// Thrown if any unexpected error occurs while publishing the message.
		/// </exception>
		Task SendToQueue(EnRabbitMQQueue queueName, string loginKey, string data);
	}
}
