using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.RabbitMQ
{
    public class RabbitMQService
    {
        private static IConnection _connection;
        private static IModel _channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost",UserName="guest",Password = "guest" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            var queueName = new string[] { "QueueA", "QueueB", "QueueC" };
            
            var exchangeName = "BestExchange";
            var routing_keys = new[] { "Get", "Set" };

            _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);


            for (int i = 0; i < queueName.Length; i++)
            {
                for (int j = 0; j < routing_keys.Length; j++)
                {
                    _channel.QueueDeclare(queueName[i], durable: false, exclusive: false, autoDelete: false, arguments: null);
                    _channel.QueueBind(queueName[i], exchangeName, routing_keys[j]);
                }
            }
        }
        public void SendMessage(string message)
        {
            if (message.Contains("Get"))
            {
                var body = Encoding.UTF8.GetBytes(message);
                _channel.BasicPublish(exchange: "BestExchange",
                                     routingKey: "Get",
                                     basicProperties: null,
                                     body: body);
            }
            else
            {
                var body = Encoding.UTF8.GetBytes(message);
                _channel.BasicPublish(exchange: "BestExchange",
                                     routingKey: "Set",
                                     basicProperties: null,
                                     body: body);
            }         
        }
        public void Close()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
