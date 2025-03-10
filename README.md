﻿# RabbitMQ Configure In .NET9

## 📌 Contents
- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [Error Handling](#error-handling)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)
- [Author](#author)
- [Disclaimer](#disclaimer)

---

## 📖 Overview
This project provides a **sample structure** with an **easy-to-use approach** for managing **message queues, listeners, and processing messages** efficiently using the **RabbitMQ.Client library (version 7.0.0) in .NET 9**. You can use this project as a **template** to create your own suitable implementation for your applications.

## 📦 Modules

### 🚀 Docker Setup
The **[Docker README](Docker/README.md)** provides instructions on how to set up a RabbitMQ container on Windows using Docker. This includes installation, running Redis via Docker Compose, and verifying the container.

📄 [Docker README](Docker/README.md)

---

### ⚙️ Redis Configuration
The **[Redis Configuration README](RabbitMQ.Configure/README.md)** explains how to configure RabbitMQ connections, define queue settings, and use the module for distributed locking.

📄 [Redis Configuration README](RabbitMQ.Configure/README.md)

---

### 📡 Redis Queue Management
The **[Redis Queue Management README](Runner/README.md)** details how to implement message queues, handle distributed locking, and integrate queue processing within an application.

📄 [Redis Queue Management README](Runner/README.md)

---
## 🚀 Features
- ✅ **Simple and Efficient**: Easy-to-use structure for handling message queues.
- 📡 **RabbitMQ Integration**: Uses `RabbitMQ.Client` to interact with RabbitMQ servers.
- ⚙️ **Configurable**: Configurable settings using `appsettings.rabbitmq.json`.
- 🔌 **Interface-based Architecture**: Implements interfaces for better flexibility and maintainability.
- 🎯 **Multi-Queue Support**: Supports multiple queues and dynamic configuration.
- 🔄 **Dependency Injection**: Can be easily integrated into modern .NET applications.

## 🛠 Getting Started

To begin, you need to set up **RabbitMQ** either on your local machine or on a server. The required **Docker Compose file** and other necessary configurations are included in the repository.

For more details, refer to the **README file inside the `Docker` folder**, where you can find specific setup instructions.

Once RabbitMQ is set up, configure the **`appsettings.rabbitmq.json`** file in the **`RabbitMQ.Configure`** module according to your RabbitMQ setup.

After that, you can run the **`Runner`** project, which is the core component of this application, and start sending your data.

More details can be found in the README files of each module.

## 🖥️ Technologies Used

- **.NET 9 (C#)**
- **RabbitMQ.Client 7.0.0**

## 🤝 Contributing

If you want to contribute to this project, feel free to submit a **pull request**.

## 📜 License
This project is licensed under the **MIT License**.

---

### 👤 Author
**Kambiz Shahriarynasab**  
📧 [saiprogrammerk@gmail.com](mailto:saiprogrammerk@gmail.com)  
🔗 [Telegram](https://t.me/pr_kami)  
📷 [Instagram](https://www.instagram.com/pr.kami.sh/)  
📺 [YouTube](https://www.youtube.com/channel/UCqjjdsFRXliDa7K612BZtmA)  
💼 [LinkedIn](https://www.linkedin.com/public-profile/settings?trk=d_flagship3_profile_self_view_public_profile)

#### ⚠️ Disclaimer
The author assumes no responsibility for any issues, damages, or losses that may arise from the use of this code. The project is provided **"as is"** without any warranties. Users should verify the implementation in their environments before deploying it in production.