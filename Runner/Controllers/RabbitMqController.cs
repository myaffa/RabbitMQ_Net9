using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Configure.Enums;
using RabbitMQ.Configure.Interfaces;

namespace Runner.Controllers {
	/// <summary>
	/// API Controller for sending messages to RabbitMQ queues.
	/// Initializes a new instance of the <see cref="RabbitMqController"/> class.
	/// </summary>
	/// <param name="rabbitMqSender">The RabbitMQ sender service.</param>
	[ApiController]
	[Route("api/[controller]")]
	public class RabbitMqController(IRabbitMQSender rabbitMqSender) : ControllerBase {
		private readonly IRabbitMQSender _rabbitMqSender = rabbitMqSender ?? throw new ArgumentNullException(nameof(rabbitMqSender), "RabbitMQ sender service cannot be null.");

		/// <summary>
		/// Sends a message to the specified RabbitMQ queue.
		/// </summary>
		/// <param name="queue">The RabbitMQ queue to send the message to.</param>
		/// <param name="text">The message content.</param>
		/// <returns>An HTTP response indicating success or failure.</returns>
		[HttpPost("{queue}")]
		public async Task<IActionResult> SendMessage([FromRoute] EnRabbitMQQueue queue, [FromBody] string text) {
			if (string.IsNullOrWhiteSpace(text)) {
				return BadRequest("Message content cannot be empty.");
			}

			try {
				await _rabbitMqSender.SendToQueue(queue, "testKey", text);
				return Ok($"✅ Message sent successfully to queue: {queue}");
			} catch (Exception ex) {
				return StatusCode(500, $"❌ Failed to send message: {ex.Message}");
			}
		}
	}
}
