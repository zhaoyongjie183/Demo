using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading;

namespace RabbitMQProject
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitMQManager rabbitMQManager = new RabbitMQManager();

            /////*发布*/
            //Console.WriteLine("请输入队列名称");
            //var queueName = Console.ReadLine();
            // Console.WriteLine("请输入发布内容");
            //var content = Console.ReadLine();
            //rabbitMQManager.PublishToDirect<string>("这是什么aaaa", "amq.direct","dirctaa", "hello");
            // rabbitMQManager.PublishToTopic<string>("这是什么aaaa", "amq.topic", "TestRouteKey.one.two", "hello");
            //rabbitMQManager.BindToTopic("amq.topic", "TestRouteKey.#", "hello");
            rabbitMQManager.Declare("hello-zyj");
            Console.WriteLine("发布完成");
            // rabbitMQManager.PublishToTopic<string>("test-zyj", "amp.topic", "zyj.*", "hello");




            //using (IConnection conn = rabbitMQManager.factory.CreateConnection())
            //{
            //    using (IModel channel = conn.CreateModel())
            //    {
            //        String queueName = "hello";
            //        //声明一个队列
            //        channel.QueueDeclare(
            //          queue: queueName,//消息队列名称
            //          durable: true,//是否缓存
            //          exclusive: false,
            //          autoDelete: false,
            //          arguments: null
            //           );
            //        //创建消费者对象
            //        var consumer = new EventingBasicConsumer(channel);
            //        consumer.Received += (model, ea) =>
            //        {
            //            byte[] message = ea.Body;//接收到的消息
            //            channel.BasicAck(ea.DeliveryTag, false);
            //        };
            //        //消费者开启监听
            //        channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
            //        Console.ReadKey();
            //    }
            //}

            //Thread th = new Thread(new ThreadStart(Exec));
            //th.Start();


            ////var sss=rabbitMQManager.Receive<string>();
            //Console.WriteLine("发布完成");
            Console.ReadLine();
        }

      
    }
}
