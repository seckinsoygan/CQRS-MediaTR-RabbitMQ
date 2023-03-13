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
            _channel.QueueDeclare(queue: "Last1",durable: false,exclusive: false,autoDelete: false,arguments: null);
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "Test1",
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
        }
        public void Close()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
