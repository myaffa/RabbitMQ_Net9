using RabbitMQ.Configure.Enums;
using RabbitMQ.Configure.Interfaces;
using Runner.Configurations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add controllers and configure JSON serialization to handle enum values as strings
builder.Services.AddControllers()
	.AddJsonOptions(options => {
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	});

// Enable API exploration and Swagger for better API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

await builder.Services.RabbitConfiguration();
Console.WriteLine("rabbit configed!");

var app = builder.Build();

// Configure Swagger UI only in development mode
if (app.Environment.IsDevelopment()) {
	app.MapOpenApi();
	app.UseSwagger();
	app.UseSwaggerUI();
}

// Map controllers to handle HTTP requests
app.MapControllers();

// Ensure RabbitMQ listener is started within an application scope
using (var scope = app.Services.CreateScope()) {
	var rabbitMqListener = scope.ServiceProvider.GetRequiredService<IRabbitMQListener>();
	await rabbitMqListener.EnsureConnectionAsync(CancellationToken.None);
}

// Run the web application
app.Run();