# Kafka with .NET: Real-Time Notification System  

A beginner-friendly project demonstrating how to integrate Apache Kafka with .NET applications. This repository provides a simple real-time notification system with producer and consumer implementations, using Docker to set up the Kafka environment.  

## Features  
- Apache Kafka setup using Docker.  
- .NET Core application with Kafka producer and consumer.  
- Real-time notification system with JSON-based messages.  
- Beginner-friendly code and detailed explanations.  

## Prerequisites  
- .NET Core SDK (version 6.0 or later).  
- Docker and Docker Compose installed.  

## Getting Started  

### 1. Clone the Repository  
```bash
git clone https://github.com/kawser2133/kafka-with-dotnet.git
cd kafka-with-dotnet
```  

### 2. Set Up Kafka with Docker  
Ensure Docker is installed and running on your system. Use the provided `docker-compose.yml` to start Kafka and Zookeeper.  
```bash
docker-compose up -d
```  

### 3. Producer Application (NotificationAPI)  

#### Build and Run the Producer  
1. Navigate to the `NotificationAPI` folder:  
   ```bash
   cd NotificationAPI
   ```  
2. Run the application:  
   ```bash
   dotnet run
   ```  

#### API Endpoint for Sending Notifications  
- **URL:** `https://localhost:5001/api/notification`  
- **Method:** POST  
- **Body:**  
   ```json
   {
     "UserId": "123",
     "Message": "Hello, Kafka!",
     "Type": "Info",
     "Timestamp": "2025-01-25T12:34:56Z"
   }
   ```  

### 4. Consumer Application  

#### Run the Consumer  
1. Navigate to the `NotificationConsumer` folder:  
   ```bash
   cd NotificationConsumer
   ```  
2. Run the application:  
   ```bash
   dotnet run
   ```  

The consumer will listen to the Kafka topic (`notifications`) and display incoming messages in the console.  


## Project Structure  
- **`NotificationAPI`**: Kafka producer application for sending messages.  
- **`NotificationConsumer`**: Kafka consumer application for processing messages.  
- **`docker-compose.yml`**: Docker setup for Kafka and Zookeeper.  


## How It Works  
1. **Producer**: Sends notifications to the Kafka topic `notifications`.  
2. **Kafka**: Acts as a message broker to store and forward messages.  
3. **Consumer**: Listens to the topic and processes notifications in real-time.  


## Example Output  

### Producer Logs  
```plaintext
Delivered to: notifications[0]@3
```  

### Consumer Logs  
```plaintext
User: 123  
Message: Hello, Kafka!  
Type: Info  
Time: 2025-01-25T12:34:56Z  
-------------------
```  

## Authors

If you have any questions or need further assistance, please contact the project author at [@kawser2133](https://www.github.com/kawser2133) || [![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/kawser2133) 

## Contributing

I want you to know that contributions to this project are welcome. Please open an issue or submit a pull request if you have any ideas, bug fixes, or improvements.

## License

This project is licensed under the [MIT License](LICENSE).
