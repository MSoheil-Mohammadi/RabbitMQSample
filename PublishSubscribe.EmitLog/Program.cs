using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

    while (true)
    {
        var message = Console.ReadLine();
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "logs",
                             routingKey: "",
                             basicProperties: null,
                             body: body);
        Console.WriteLine(" [x] Sent {0}", message);
    }
}

Console.ReadLine();