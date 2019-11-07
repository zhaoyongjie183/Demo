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


        public void Declare(string queueName)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //queue 队列名称,durable是否持久化，Exclusive：排他队列，Auto-delete:自动删除
                    channel.QueueDeclare(queueName, true, false, false, null);

                }
            }
        }

        public void Publish<T>(T message, string queueName)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //queue 队列名称,durable是否持久化，Exclusive：排他队列，Auto-delete:自动删除
                    channel.QueueDeclare(queueName, true, false, false, null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    IBasicProperties props = channel.CreateBasicProperties();
                    props.ContentType = "text/plain";
                    props.DeliveryMode = 2;
                    props.Persistent = true;

                    //告诉Rabbit每次只能向消费者发送一条信息,再消费者未确认之前,不再向他发送信息
                    channel.BasicQos(0, 1, false);

                    channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: props, body: body);
                }
            }
        }


        public void PublishToTopic<T>(T message, string exchangeName, string routeKey, string queueName)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //定义一个Topic类型交换机
                    channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, true, false, null);

                    // 定义队列 queue 队列名称,durable是否持久化，Exclusive：排他队列，Auto-delete:自动删除
                    channel.QueueDeclare(queueName, true, false, false, null);

                    //将队列绑定到交换机
                    channel.QueueBind(queueName, exchangeName, routeKey, null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    IBasicProperties props = channel.CreateBasicProperties();
                    props.ContentType = "text/plain";
                    props.DeliveryMode = 2;
                    props.Persistent = true;

                    channel.BasicPublish(exchange: exchangeName, routingKey: routeKey, basicProperties: props, body: body);

                }
            }
        }

        public void PublishToDirect<T>(T message, string exchangeName, string routeKey, string queueName)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //定义一个Topic类型交换机
                    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, true, false, null);

                    // 定义队列 queue 队列名称,durable是否持久化，Exclusive：排他队列，Auto-delete:自动删除
                    channel.QueueDeclare(queueName, true, false, false, null);

                    //将队列绑定到交换机
                    //channel.QueueBind(queueName, exchangeName, routeKey, null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    IBasicProperties props = channel.CreateBasicProperties();
                    props.ContentType = "text/plain";
                    props.DeliveryMode = 2;
                    props.Persistent = true;

                    channel.BasicPublish(exchange: exchangeName, routingKey: routeKey, basicProperties: props, body: body);

                }
            }
        }
        public void PublishToFanout<T>(T message, string exchangeName, string routeKey, string queueName)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //定义一个Topic类型交换机
                    channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, true, false, null);

                    // 定义队列 queue 队列名称,durable是否持久化，Exclusive：排他队列，Auto-delete:自动删除
                    channel.QueueDeclare(queueName, true, false, false, null);

                    //将队列绑定到交换机
                    channel.QueueBind(queueName, exchangeName, routeKey, null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    IBasicProperties props = channel.CreateBasicProperties();
                    props.ContentType = "text/plain";
                    props.DeliveryMode = 2;
                    props.Persistent = true;

                    channel.BasicPublish(exchange: exchangeName, routingKey: routeKey, basicProperties: props, body: body);

                }
            }
        }

        public void BindToTopic(string exchangeName, string routeKey, string queueName)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //定义一个Topic类型交换机
                    channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, true, false, null);

                    //将队列绑定到交换机
                    channel.QueueBind(queueName, exchangeName, routeKey, null);

                }
            }
        }
    }
}
