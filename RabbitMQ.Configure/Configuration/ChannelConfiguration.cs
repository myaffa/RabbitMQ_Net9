using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Configure.Enums;

namespace RabbitMQ.Configure.Configuration {
	/// <summary>
	/// Provides configuration methods for setting up RabbitMQ queues and exchanges.
	/// This class demonstrates the various types of queues and their configurations.
	/// </summary>
	public static class ChannelConfiguration {
		/// <summary>
		/// Configures RabbitMQ message queues and exchanges with different properties.
		/// </summary>
		/// <param name="services">Dependency injection container.</param>
		/// <param name="connection">RabbitMQ connection instance.</param>
		/// <param name="ttlForBroadcast">Time-to-live (TTL) for messages in broadcast queues (in milliseconds).</param>
		/// <returns>Updated IServiceCollection with RabbitMQ configurations.</returns>
		public static async Task<IServiceCollection> ConfigureQueuesAndExchanges(this IServiceCollection services, IConnection connection, int ttlForBroadcast) {
			Console.WriteLine("🚀 Configuring queues and exchanges...");
			IChannel channel = await connection.CreateChannelAsync();
			try {
				// 1️⃣ Durable Queue - persists messages across broker restarts.
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuSolid.ToString(), durable: true, exclusive: false, autoDelete: false);
				Console.WriteLine("✅ DurableQueue created!");

				// 2️⃣ Transient Queue - messages are lost if the broker restarts.
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuTransient.ToString(), durable: false, exclusive: false, autoDelete: true);
				Console.WriteLine("✅ TransientQueue created!");

				// 3️⃣ Exclusive Queue - only accessible by the connection that created it.
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuExclusive.ToString(), durable: false, exclusive: true, autoDelete: true);
				Console.WriteLine("✅ ExclusiveQueue created!");

				// 4️⃣ Auto-Delete Queue - automatically deleted when all consumers disconnect.
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuAutoDelete.ToString(), durable: true, exclusive: false, autoDelete: true);
				Console.WriteLine("✅ AutoDeleteQueue created!");

				// 5️⃣ Max-Length Queue - limits the maximum number of stored messages.
				var maxLengthArguments = new Dictionary<string, object?> {
					{ "x-max-length", 1000 }
				};
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuMaxLength.ToString(), durable: true, exclusive: false, autoDelete: false, arguments: maxLengthArguments);
				Console.WriteLine("✅ MaxLengthQueue created!");

				// 6️⃣ TTL Queue - messages expire after a specified time.
				var ttlArguments = new Dictionary<string, object?> {
					{ "x-message-ttl", ttlForBroadcast }
				};
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuTTL.ToString(), durable: true, exclusive: false, autoDelete: false, arguments: ttlArguments);
				Console.WriteLine("✅ TTLQueue created!");

				// 7️⃣ Delayed Queue - messages are delivered after a delay.
				var delayedArguments = new Dictionary<string, object?> {
					{ "x-delayed-type", "direct" }
				};
				await channel.ExchangeDeclareAsync("DelayedExchange", "x-delayed-message", durable: true, arguments: delayedArguments);
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuDelayed.ToString(), durable: true, exclusive: false, autoDelete: false);
				await channel.QueueBindAsync(EnRabbitMQQueue.QueuDelayed.ToString(), "DelayedExchange", "delayed");
				Console.WriteLine("✅ DelayedQueue created!");

				// 8️⃣ Dead-Letter Queue (DLX) - handles messages that fail processing.
				var dlxArguments = new Dictionary<string, object?> {
					{ "x-dead-letter-exchange", "DLXExchange" }
				};
				await channel.ExchangeDeclareAsync("DLXExchange", ExchangeType.Direct);
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuDLX.ToString(), durable: true, exclusive: false, autoDelete: false);
				await channel.QueueDeclareAsync("MainQueueWithDLX", durable: true, exclusive: false, autoDelete: false, arguments: dlxArguments);
				await channel.QueueBindAsync(EnRabbitMQQueue.QueuDLX.ToString(), "DLXExchange", "dlx-routing-key");
				Console.WriteLine("✅ DLXQueue and MainQueueWithDLX created!");

				// 9️⃣ Deduplication Queue - prevents duplicate messages.
				var dedupArguments = new Dictionary<string, object?> {
					{ "x-message-deduplication", true }
				};
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuDeduplication.ToString(), durable: true, exclusive: false, autoDelete: false, arguments: dedupArguments);
				Console.WriteLine("✅ Deduplication Queue created!");

				// 🔟 Priority Queue - prioritizes messages based on assigned priority levels.
				var priorityArguments = new Dictionary<string, object?> {
					{ "x-max-priority", 10 }
				};
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuPriority.ToString(), durable: true, exclusive: false, autoDelete: false, arguments: priorityArguments);
				Console.WriteLine("✅ Priority Queue created!");

				// 1️⃣1️⃣ Lazy Queue - stores messages on disk to conserve RAM.
				var lazyArguments = new Dictionary<string, object?> {
					{ "x-queue-mode", "lazy" }
				};
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuLazy.ToString(), durable: true, exclusive: false, autoDelete: false, arguments: lazyArguments);
				Console.WriteLine("✅ Lazy Queue created!");

				// 1️⃣2️⃣ Quorum Queue - a fault-tolerant queue type using multiple nodes.
				var quorumArguments = new Dictionary<string, object?> {
					{ "x-queue-type", "quorum" }
				};
				await channel.QueueDeclareAsync(EnRabbitMQQueue.QueuQuorum.ToString(), durable: true, exclusive: false, autoDelete: false, arguments: quorumArguments);
				Console.WriteLine("✅ Quorum Queue created!");

				// Exchange configurations
				await channel.ExchangeDeclareAsync("FanoutExchange", ExchangeType.Fanout);
				await channel.ExchangeDeclareAsync("DirectExchange", ExchangeType.Direct);
				await channel.ExchangeDeclareAsync("TopicExchange", ExchangeType.Topic);
				Console.WriteLine("✅ All exchanges created!");

				// Queue Bindings
				await channel.QueueBindAsync(EnRabbitMQQueue.QueuSolid.ToString(), "FanoutExchange", "");
				await channel.QueueBindAsync(EnRabbitMQQueue.QueuMaxLength.ToString(), "DirectExchange", "max-length");
				await channel.QueueBindAsync(EnRabbitMQQueue.QueuTTL.ToString(), "TopicExchange", "ttl.#");
				Console.WriteLine("✅ All queues bound to exchanges!");
			} catch (Exception ex) {
				Console.WriteLine($"❌ Error configuring queues: {ex}");
			}

			services.AddSingleton(channel);
			return services;
		}
	}
}