using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Producer Started!");
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            QueueProducer.Publish(channel);

        }
    }
}
