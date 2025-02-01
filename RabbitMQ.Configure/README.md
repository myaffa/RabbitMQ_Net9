# RabbitMQ.Configure

## Overview
This module provides an abstraction layer for managing RabbitMQ connections, queues, and message processing in a structured and efficient manner.

## Features
- **Queue Configuration**: Easily define and manage RabbitMQ queues.
- **Message Processing**: Interface-driven approach for handling incoming messages.
- **Publisher & Consumer Support**: Supports sending and receiving messages efficiently.
- **Dependency Injection**: Seamless integration with .NET applications.

## Installation
Ensure you have RabbitMQ running. You can set up RabbitMQ using Docker as explained in the main project.

## Configuration
Configuration is managed through the `appsettings.rabbitmq.json` file located in the `Configuration` folder. Example:

```json
{
  "Queues": [
    {
      "Name": "queue1",
      "Durable": true,
      "AutoDelete": false
    },
    {
      "Name": "queue2",
      "Durable": true,
      "AutoDelete": false
    }
  ],
  "Connection": {
    "Host": "localhost",
    "Port": 5672,
    "Username": "admin",
    "Password": "password"
  }
}
```

### Important Notes
- This configuration should match the RabbitMQ settings in your environment.
- Ensure the queues are correctly configured before running the application.

## Components
### Configuration
- `RabbitMqConfiguration.cs`: Manages RabbitMQ connection settings.
- `ChannelConfiguration.cs`: Defines how channels interact with queues.

### Interfaces
- `IMessageHandler`: Interface for handling messages.
- `IMessageProcessor`: Processes incoming messages.
- `IRabbitMQListener`: Handles subscription to queues.
- `IRabbitMQSender`: Sends messages to RabbitMQ.

### Services
- `RabbitMQSender.cs`: Implements message publishing.
- `RabbitMQListener.cs`: Implements message consumption.
- `MessageProcessor.cs`: Handles message processing logic.
- `MessageHandlerFactory.cs`: Factory pattern for message handlers.

## Usage
To send a message:
```csharp
var sender = new RabbitMQSender(configuration);
sender.SendMessage("queue1", "Hello, RabbitMQ!");
```

To listen for messages:
```csharp
var listener = new RabbitMQListener(configuration, messageProcessor);
listener.StartListening("queue1");
```

## License
This module is licensed under the MIT License.

### Author

[Kambiz Shahriarynasab]\
[[saiprogrammerk@gmail.com](mailto:saiprogrammerk@gmail.com)]\
[[https://t.me/pr_kami](https://t.me/pr_kami)]\
[https://www.instagram.com/pr.kami.sh/]\
[[https://www.youtube.com/channel/UCqjjdsFRXliDa7K612BZtmA](https://www.youtube.com/channel/UCqjjdsFRXliDa7K612BZtmA)]\
[https://www.linkedin.com/public-profile/settings?trk=d_flagship3_profile_self_view_public_profile]

#### Disclaimer
The author of this project assumes no responsibility for any issues, damages, or losses that may arise from the use of this code. The project is provided "as is" without any warranties, including but not limited to functionality, security, or suitability for a particular purpose. Users should thoroughly test and verify the implementation in their own environments before deploying it in production.

