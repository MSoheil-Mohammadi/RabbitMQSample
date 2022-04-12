using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Work Queues New Task");

// create connection to Server
ConnectionFactory factory = new() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
// create channel
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "task_queue",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

    while (true)
    {
        var message = Console.ReadLine();
        var body = Encoding.UTF8.GetBytes(message);

        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(exchange: "",
                             routingKey: "task_queue",
                             basicProperties: properties,
                             body: body);
        Console.WriteLine(" [x] Sent {0}", message);
    }
}

Console.ReadLine();