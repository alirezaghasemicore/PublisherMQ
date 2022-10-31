using Application.Interfaces;
using Domain.ViewModels;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SendMessageService : ISendMessageService
    {
        public void SendMessageToRabbitMQ(SendMessage_ViewModel sendMessage)
        {
            RabbitMQ_ViewModel rabbitMQ = new RabbitMQ_ViewModel();
            rabbitMQ.Host_Name = "localhost";
            rabbitMQ.User_Name = "guest";
            rabbitMQ.Password = "guest";
            var factory = new ConnectionFactory() { HostName = rabbitMQ.Host_Name };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "inbox",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = sendMessage.Message;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "inbox",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
