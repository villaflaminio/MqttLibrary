using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;


namespace MqttLibrary.Publisher
{
    public class Publisher
    {
        public static async void Run()

        {
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
            });
            client.UseDisconnectedHandler(e =>
            {
                Console.WriteLine("Disconnect");
            });

            client.ConnectAsync(otions);


            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Invio " + i);
                await PublishMessageAsync(client, i);
                Task.Delay(500).Wait();

                PublishMessageAsync(client, i);
            }



        }

        private static async Task PublishMessageAsync(IMqttClient client, int i)
        {

            string mex = "Hello " + i;

            var message = new MqttApplicationMessageBuilder()
                .WithTopic("flaminio")
                .WithPayload(mex)
                .WithAtLeastOnceQoS()
                .Build();

            if (client.IsConnected)
            {
                await client.PublishAsync(message);
            }

        }
    }
}
