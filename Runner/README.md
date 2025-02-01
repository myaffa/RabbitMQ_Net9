# Runner - Core Application Module

## Contents

- [Overview](#Overview)
- [Features](#Features)
- [Installation](#Installation)
- [Configuration](#Configuration)
- [Components](#Components)
- [Usage](#Usage)
- [License](#License)

---

## Overview
The `Runner` module is the core application responsible for managing message queuing, processing, and communication with RabbitMQ. It integrates with `RabbitMQ.Configure` and provides a structured approach to handling different types of message queues.

## Features
- **Queue Management**: Supports various queue types, including auto-delete, broadcast, delayed, priority, and more.
- **Message Processing**: Implements different handlers for specialized queue processing.
- **Configuration Driven**: Uses `RabbitMQ.Configure` for all RabbitMQ-related settings.
- **REST API Integration**: Provides endpoints via `RabbitMqController` for interacting with RabbitMQ.

## Installation
Ensure RabbitMQ is running before starting the application. You can set up RabbitMQ using Docker as explained in the main project's documentation.

## Configuration
All RabbitMQ-related configurations are managed within the `RabbitMQ.Configure` module, specifically in the `appsettings.rabbitmq.json` file. Ensure that the correct settings are defined in this file before running the application.

For reference, you can find detailed configuration options in the `RabbitMQ.Configure` module, which includes settings for queues, exchanges, and other RabbitMQ parameters.

## Components
### Configuration
- `RabbitMQ.Configure`: Manages all RabbitMQ-related settings.

### Controllers
- `RabbitMqController.cs`: Provides API endpoints to interact with RabbitMQ.

### Message Handlers
Located in the `Messaging` folder, handling various queue types:
- `QueuAutoDeleteHandler.cs`
- `QueuBroudcastHandler.cs`
- `QueuDelayedHandler.cs`
- `QueuPriorityHandler.cs`
- `QueuTTLHandler.cs`
- And more...

## Usage
### Running the Application
Execute the application via .NET CLI:
```sh
dotnet run --project Runner
```

### API Interaction
You can send messages using the API. Example request:
```sh
curl -X POST http://localhost:5000/api/rabbitmq/send -H "Content-Type: application/json" -d '{"queue": "queue1", "message": "Hello, RabbitMQ!"}'
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

