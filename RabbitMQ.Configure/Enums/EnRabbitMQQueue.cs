using System.Runtime.Serialization;

namespace RabbitMQ.Configure.Enums {
	/// <summary>
	/// Enumeration for RabbitMQ queues.
	/// This Enum defines all queue names to maintain consistency and avoid hardcoded strings.
	/// </summary>
	public enum EnRabbitMQQueue {
		/// <summary>
		/// Solid queue - a durable queue for persistent messages.
		/// </summary>
		[EnumMember(Value = "QueuSolid")]
		QueuSolid,

		/// <summary>
		/// Broadcast queue - used for fanout exchange messages.
		/// </summary>
		[EnumMember(Value = "QueuBroudcast")]
		QueuBroudcast,

		/// <summary>
		/// Transient queue - deleted after the connection is closed.
		/// </summary>
		[EnumMember(Value = "QueuTransient")]
		QueuTransient,

		/// <summary>
		/// Exclusive queue - can only be accessed by one connection and is deleted when the connection closes.
		/// </summary>
		[EnumMember(Value = "QueuExclusive")]
		QueuExclusive,

		/// <summary>
		/// Auto-delete queue - deleted automatically when no consumers remain.
		/// </summary>
		[EnumMember(Value = "QueuAutoDelete")]
		QueuAutoDelete,

		/// <summary>
		/// Queue with a maximum number of messages allowed.
		/// </summary>
		[EnumMember(Value = "QueuMaxLength")]
		QueuMaxLength,

		/// <summary>
		/// Queue with message TTL (Time-to-Live).
		/// Messages expire after a specific time.
		/// </summary>
		[EnumMember(Value = "QueuTTL")]
		QueuTTL,

		/// <summary>
		/// Delayed queue - messages are delivered with a delay.
		/// </summary>
		[EnumMember(Value = "QueuDelayed")]
		QueuDelayed,

		/// <summary>
		/// Dead-letter queue (DLX) - stores undelivered or rejected messages.
		/// </summary>
		[EnumMember(Value = "QueuDLX")]
		QueuDLX,

		/// <summary>
		/// Deduplication queue - prevents duplicate messages from being inserted.
		/// </summary>
		[EnumMember(Value = "QueuDeduplication")]
		QueuDeduplication,

		/// <summary>
		/// Priority queue - messages are processed based on priority.
		/// </summary>
		[EnumMember(Value = "QueuPriority")]
		QueuPriority,

		/// <summary>
		/// Lazy queue - stores messages on disk instead of RAM.
		/// </summary>
		[EnumMember(Value = "QueuLazy")]
		QueuLazy,

		/// <summary>
		/// Quorum queue - highly available queue for distributed messaging.
		/// </summary>
		[EnumMember(Value = "QueuQuorum")]
		QueuQuorum
	}
}
