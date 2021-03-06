using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Receive");

ConnectionFactory factory = new() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "Hello",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        global::System.Console.WriteLine(" [x] Received {0}", message);
    };

    channel.BasicConsume(queue: "Hello", autoAck:true, consumer:consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}