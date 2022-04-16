﻿using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "direct_logs",
                            type: "direct");

    while (true)
    {
        Console.Write("enter severity: ");
        var severity = Console.ReadLine();//(args.Length > 0) ? args[0] : "info";
        Console.Write("enter message: ");
        var message = Console.ReadLine(); //(args.Length > 1)
                                          //? string.Join(" ", args.Skip(1).ToArray())
                                          //: "Hello World!";
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "direct_logs",
                             routingKey: severity,
                             basicProperties: null,
                             body: body);
        Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, message);
    }
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();