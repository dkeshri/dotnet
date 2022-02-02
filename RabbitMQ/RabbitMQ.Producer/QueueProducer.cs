using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQ.Producer
{
    public static class QueueProducer
    {
        public static void Publish(IModel channel)
        {
            channel.QueueDeclare("demo-Queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                null
            );
            var message = new { Name = "Producer", Message = "Hello!" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("", "demo-queue", null, body: body);
        }
    }
}