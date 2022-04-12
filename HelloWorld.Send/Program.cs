using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Receive");

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

    string message = "Hello World!";
    byte[] body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "",
                         routingKey: "Hello",
                         basicProperties: null,
                         body: body);

    Console.WriteLine($" [x] Sent {message}");
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();