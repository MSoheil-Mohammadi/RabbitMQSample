using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Work Queues Worker2");

ConnectionFactory factory = new() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "task_queue",
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

        int dots = message.Split('.').Length - 1;
        Thread.Sleep(dots * 1000);

        global::System.Console.WriteLine(" [x] done ");
    };

    channel.BasicConsume(queue: "task_queue", autoAck: true, consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}