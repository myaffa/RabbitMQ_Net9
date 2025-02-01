# RabbitMQ Configure In .NET9

## Overview

This project provides a sample structure with an easy-to-use approach for managing message queues, listeners, and processing messages efficiently using the **RabbitMQ.Client library (version 7.0.0) in .NET 9**. You can use this project as a template to create your own suitable implementation for your applications.

## Features

- **Simple and Efficient**: Easy-to-use structure for handling message queues.
- **RabbitMQ Integration**: Uses `RabbitMQ.Client` to interact with RabbitMQ servers.
- **Configurable**: Configurable settings using `appsettings.rabbitmq.json`.
- **Interface-based Architecture**: Implements interfaces for better flexibility and maintainability.
- **Multi-Queue Support**: Supports multiple queues and dynamic configuration.
- **Dependency Injection**: Can be easily integrated into modern .NET applications.

## Getting Started

To begin, you need to set up RabbitMQ either on your local machine or on a server. The required Docker Compose file and other necessary configurations are included in the attachments.

For more details, refer to the README file inside the `Docker` folder, where you can find specific setup instructions.

Once RabbitMQ is set up, configure the `appsettings.rabbitmq.json` file in the `RabbitMQ.Configure` module according to your RabbitMQ setup.

After that, you can run the `Runner` project, which is the core component of this application, and start sending your data.

More details can be found in the README files of each module.

## Technologies Used

- **.NET 9 (C#)**
- **RabbitMQ.Client 7.0.0**

## Contributing

If you want to contribute to this project, feel free to submit a pull request.

## License

This project is licensed under the **MIT License**. Feel free to modify and use it in your projects.

---

### Author

[Kambiz Shahriarynasab]\
[[saiprogrammerk@gmail.com](mailto:saiprogrammerk@gmail.com)]\
[[https://t.me/pr_kami](https://t.me/pr_kami)]\
[https://www.instagram.com/pr.kami.sh/]\
[[https://www.youtube.com/channel/UCqjjdsFRXliDa7K612BZtmA](https://www.youtube.com/channel/UCqjjdsFRXliDa7K612BZtmA)]\
[https://www.linkedin.com/public-profile/settings?trk=d_flagship3_profile_self_view_public_profile]

#### Disclaimer
The author of this project assumes no responsibility for any issues, damages, or losses that may arise from the use of this code. The project is provided "as is" without any warranties, including but not limited to functionality, security, or suitability for a particular purpose. Users should thoroughly test and verify the implementation in their own environments before deploying it in production.

