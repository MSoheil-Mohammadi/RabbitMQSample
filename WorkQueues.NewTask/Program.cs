using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Work Queues New Task");

// create connection to Server
ConnectionFactory factory = new() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
// create channel
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "Hello",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    string message = GetMessage(args);
    byte[] body = Encoding.UTF8.GetBytes(message);

    var properties = channel.CreateBasicProperties();
    properties.Persistent = true;

    channel.BasicPublish(exchange: "",
                         routingKey: "task_queue",
                         basicProperties: properties,
                         body: body);

    Console.WriteLine($" [x] Sent {message}");
}

string GetMessage(string[] args)
{
    return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();