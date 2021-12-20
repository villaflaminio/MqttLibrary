using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MqttSubscriber.model;
using MqttSubscriber.repository;

namespace MqttLibrary.Subscriber
{
    public class SubscriberSave
    {
        public static void Run()
        {
            var db = new Repository();

            var mqttFactory = new MqttFactory();
            var client = mqttFactory.CreateMqttClient();
            var otions = new MqttClientOptionsBuilder()
                .WithClientId(Guid.NewGuid().ToString())
                .WithTcpServer("localhost", 1884)
                .WithCleanSession()
                .Build();

            client.UseConnectedHandler(e =>
            {
                Console.WriteLine("connected to broker");
                var topicFilter = new TopicFilterBuilder()
                .WithTopic("flaminio")
                .Build();
                client.SubscribeAsync(topicFilter);

            });
            client.UseDisconnectedHandler(e =>
            {
                Console.WriteLine("Disconnect");
            });

            client.UseApplicationMessageReceivedHandler(e =>
            {
                var message = new MessageMqtt() { Topic = e.ApplicationMessage.Topic, Payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload) };
                db.Messages.Add(message);

                Console.WriteLine("--- Save message ---" + message);
               
                db.SaveChanges();

                //Console.WriteLine($"Ricevuto: {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            });
            client.ConnectAsync(otions);



        }
    }
}
