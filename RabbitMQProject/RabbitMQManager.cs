using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQProject
{
    /// <summary>	
    /// 描述：MQ消息队列中间层
    /// 创建人： zhaoyongjie
    /// 创建时间：2019/7/30 16:58:19
    /// </summary>
    public class RabbitMQManager
    {
        //ConnectionFactory（连接管理器）、Channel（信道）、Exchange（交换器）、Queue（队列）、RoutingKey（路由键）、BindingKey（绑定键）
        /*
        ConnectionFactory（连接管理器）：应用程序与Rabbit之间建立连接的管理器，程序代码中使用；

        Channel（信道）：消息推送使用的通道；

        Exchange（交换器）：用于接受、分配消息；

        Queue（队列）：用于存储生产者的消息；

        RoutingKey（路由键）：用于把生成者的数据分配到交换器上；

        BindingKey（绑定键）：用于把交换器的消息绑定到队列上；
        */
        private ConnectionFactory factory;
        public RabbitMQManager()
        {
            factory = new ConnectionFactory() {
                HostName = "10.0.75.1",
                UserName= "guest",
                Password= "guest",
                VirtualHost="/"
            };
        }

        public void Publish<T>(T message)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //queue 队列名称,durable是否持久化，Exclusive：排他队列，Auto-delete:自动删除
                    //durable
                    channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);

                }
            }
        }

        public void Receive()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
