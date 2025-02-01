using RabbitMQ.Configure.Enums;
using System.Threading.Tasks;

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
		/// The name of the RabbitMQ queue where the message should be sent.
		/// </param>
		/// <param name="loginKey">
		/// A unique identifier for the sender of the message.
		/// This can be used for tracking or authentication purposes.
		/// </param>
		/// <param name="data">
		/// The message content to be sent to the queue.
		/// </param>
		/// <returns>
		/// A <see cref="Task"/> representing the asynchronous operation of sending the message.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if <paramref name="loginKey"/> or <paramref name="data"/> is null or empty.
		/// </exception>
		Task SendToQueue(EnRabbitMQQueue queueName, string loginKey, string data);
	}
}
