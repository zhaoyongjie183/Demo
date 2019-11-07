using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQReceive
{
    /// <summary>	
    /// 描述：
    /// 创建人： zhaoyongjie
    /// 创建时间：2019/8/8 9:13:40
    /// </summary>
    public class RabbitMQManager
    {
        public ConnectionFactory factory;
        public RabbitMQManager()
        {

            factory = new ConnectionFactory()
            {
                HostName = "192.168.200.112",
                UserName = "admin",
                Password = "123456",
                VirtualHost = "test-9825"
            };
        }
        public void Receive(string queueName)
        {
            var message = "";
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queueName, true, false, false, null);
            //告诉Rabbit每次只能向消费者发送一条信息,再消费者未确认之前,不再向他发送信息
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                message = Encoding.UTF8.GetString(body);
                Console.WriteLine("收到消息："+message);
                //返回消息确认(手动)
                channel.BasicAck(ea.DeliveryTag, false);
                Console.ReadKey();
            };
            // 消费者开启监听
            //将autoAck设置false 关闭自动确认
            channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

        }
    }
}
