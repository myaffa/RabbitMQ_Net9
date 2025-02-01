# RabbitMQ.Configure

## Contents

- [Overview](#overview)
- [Features](#features)
- [Installation](#installation)
- [Configuration](#configuration)
- [Components](#components)
- [Usage](#usage)
- [License](#license)
- [Author](#author)
- [Disclaimer](#disclaimer)

---

## Overview

This module provides an abstraction layer for managing RabbitMQ connections, queues, and message processing in a structured and efficient manner. It simplifies the integration of RabbitMQ with .NET applications by offering a well-defined interface for sending and receiving messages.

## Features

- **Queue Configuration**: Easily define and manage RabbitMQ queues.
- **Message Processing**: Interface-driven approach for handling incoming messages.
- **Publisher & Consumer Support**: Supports sending and receiving messages efficiently.
- **Dependency Injection**: Seamless integration with .NET applications.
- **Scalability**: Supports multiple queues and distributed processing.
- **Error Handling**: Built-in logging and exception management.

## Installation

Ensure you have RabbitMQ running. You can set up RabbitMQ using Docker as explained in the main project. If RabbitMQ is running in a cloud-based environment, ensure network access and authentication settings match the configuration.

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
- Ensure the RabbitMQ server settings match your configuration file.
- Proper authentication and authorization should be in place.

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

### Sending Messages

To send a message:
```csharp
var sender = new RabbitMQSender(configuration);
sender.SendMessage("queue1", "Hello, RabbitMQ!");
```

### Listening for Messages

To listen for messages:
```csharp
var listener = new RabbitMQListener(configuration, messageProcessor);
listener.StartListening("queue1");
```

## License

This module is licensed under the MIT License.

## Author

[Kambiz Shahriarynasab]  
[[saiprogrammerk@gmail.com](mailto:saiprogrammerk@gmail.com)]  
[[https://t.me/pr_kami](https://t.me/pr_kami)]  
[https://www.instagram.com/pr.kami.sh/]  
[[https://www.youtube.com/channel/UCqjjdsFRXliDa7K612BZtmA](https://www.youtube.com/channel/UCqjjdsFRXliDa7K612BZtmA)]  
[https://www.linkedin.com/public-profile/settings?trk=d_flagship3_profile_self_view_public_profile]

## Disclaimer

The author of this project assumes no responsibility for any issues, damages, or losses that may arise from the use of this code. The project is provided "as is" without any warranties, including but not limited to functionality, security, or suitability for a particular purpose. Users should thoroughly test and verify the implementation in their own environments before deploying it in production.

---

