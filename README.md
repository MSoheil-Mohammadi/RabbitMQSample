# RabbitMQSample
RabbitMQ Doc's Examples


## "Hello World!" Introduction
RabbitMQ is a message broker: it accepts and forwards messages.
You can think about it as a post office:
when you put the mail that you want posting in a post box,
you can be sure that the letter carrier will eventually deliver the mail to your recipient.
In this analogy, RabbitMQ is a post box, a post office, and a letter carrier.

Producing means nothing more than sending. A program that sends messages is a producer.

A queue is the name for a post box which lives inside RabbitMQ.
it's essentially a large message buffer.

Many producers can send messages that go to one queue, and many consumers can try to receive data from one queue.

Consuming has a similar meaning to receiving. A consumer is a program that mostly waits to receive messages.

Note that the producer, consumer, and broker do not have to reside on the same host.
An application can be both a producer and consumer, too.
