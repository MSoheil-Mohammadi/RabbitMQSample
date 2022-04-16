using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "topic_logs",
                            type: "topic");
    while (true)
    {
        Console.Write("routingKey : ");
        var routingKey = Console.ReadLine();//(args.Length > 0) ? args[0] : "anonymous.info";
        Console.Write("message : ");
        var message = Console.ReadLine();
        //(args.Length > 1)
        //          ? string.Join(" ", args.Skip(1).ToArray())
        //          : "Hello World!";
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "topic_logs",
                             routingKey: routingKey,
                             basicProperties: null,
                             body: body);
        Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
    }
}