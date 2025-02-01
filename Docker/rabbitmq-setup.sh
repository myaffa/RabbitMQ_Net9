#!/bin/bash

# Start RabbitMQ server
rabbitmq-server &

# Wait for RabbitMQ server to start
sleep 10

# Create default vhost and set permissions
rabbitmqctl add_vhost /
rabbitmqctl set_permissions -p / admin ".*" ".*" ".*"

# Keep the container running
tail -f /dev/null