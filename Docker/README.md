# RabbitMQ Docker Setup

## 📌 Contents
- [Overview](#overview)
- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
- [Files Overview](#files-overview)
- [Cleanup](#cleanup)
- [Troubleshooting](#troubleshooting)
- [License](#license)
- [Author](#author)
- [Disclaimer](#disclaimer)

---

## 📖 Overview
This directory contains the necessary files to set up a **RabbitMQ server** using Docker. It provides a simple way to deploy a **message broker** with a management interface for monitoring and administration.

## 🛠 Prerequisites
Ensure you have the following installed before proceeding:

- **Docker**
- **Docker Compose**

## 🚀 Setup Instructions

### 1️⃣ Start RabbitMQ
Run the following command to start RabbitMQ using Docker Compose:

```sh
docker-compose up -d
```
This will pull the RabbitMQ image (with the management UI) and start the container.

### 2️⃣ Verify RabbitMQ is Running
Access the RabbitMQ management UI by visiting:

```
http://localhost:15672/
```

**Default login credentials:**
- **Username:** admin
- **Password:** password

### 3️⃣ Access the RabbitMQ Container
To enter the RabbitMQ container shell:

```sh
docker exec -it rabbitmq bash
```

### 4️⃣ Enable Delayed Message Exchange Plugin
To enable the `rabbitmq_delayed_message_exchange` plugin:

```sh
rabbitmq-plugins enable rabbitmq_delayed_message_exchange
```

If the plugin is not found, download the latest version from:
[RabbitMQ Delayed Message Exchange](https://github.com/rabbitmq/rabbitmq-delayed-message-exchange/releases)

Copy the plugin into the container:
```sh
docker cp rabbitmq_delayed_message_exchange-4.0.2.ez rabbitmq:/plugins/
```
Enable the plugin:
```sh
rabbitmq-plugins enable rabbitmq_delayed_message_exchange
```

### 5️⃣ Restart RabbitMQ
Restart RabbitMQ after enabling the plugin:
```sh
rabbitmqctl stop
rabbitmq-server -detached
```

## 📂 Files Overview

### `docker-compose.yml`
This file defines the **RabbitMQ service** with the following configuration:

- **Ports:**
  - `5672:5672` (AMQP protocol for messaging)
  - `15672:15672` (Management UI)
- **Environment Variables:**
  - `RABBITMQ_DEFAULT_USER=admin`
  - `RABBITMQ_DEFAULT_PASS=password`
- **Persistent Storage:**
  - Volume `rabbitmq_data` is used to persist data.
- **Custom Script Execution:**
  - `rabbitmq-setup.sh` initializes RabbitMQ settings on startup.

### `rabbitmq-setup.sh`
This script:
- Starts the RabbitMQ server.
- Waits for it to fully initialize.
- Adds a default **vhost** and sets up permissions for the `admin` user.
- Keeps the container running indefinitely.

## 🗑️ Cleanup

To stop and remove the RabbitMQ container:
```sh
docker-compose down
```

To remove all data:
```sh
docker volume rm rabbitmq_data
```

## 🛠 Troubleshooting
If you encounter issues:

- Check container logs:
  ```sh
  docker logs rabbitmq
  ```
- Restart the container:
  ```sh
  docker-compose restart
  ```
- Verify RabbitMQ service status inside the container:
  ```sh
  rabbitmqctl status
  ```

## 📜 License
This project is licensed under the **MIT License**.

## 👤 Author
**Kambiz Shahriarynasab**  
📧 [saiprogrammerk@gmail.com](mailto:saiprogrammerk@gmail.com)  
🔗 [Telegram](https://t.me/pr_kami)  
📷 [Instagram](https://www.instagram.com/pr.kami.sh/)  
📺 [YouTube](https://www.youtube.com/channel/UCqjjdsFRXliDa7K612BZtmA)  
💼 [LinkedIn](https://www.linkedin.com/public-profile/settings?trk=d_flagship3_profile_self_view_public_profile)

## ⚠️ Disclaimer
The author assumes no responsibility for any issues, damages, or losses that may arise from the use of this code. The project is provided **"as is"** without any warranties. Users should verify the implementation in their environments before deploying it in production.

