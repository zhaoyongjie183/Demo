using System;

namespace RabbitMQReceive
{
    class Program
    {
        static void Main(string[] args)
        {

            RabbitMQManager rabbitMQManager = new RabbitMQManager();
            rabbitMQManager.Receive("hello");
            Console.ReadLine();
        }
    }
}
