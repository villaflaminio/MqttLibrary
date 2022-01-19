using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;

namespace MqttLibrary.Broker
{
    public class Broker
    {

        public static void Run()
        {
            //configure options
            var optionsBuilder = new MqttServerOptionsBuilder()
                .WithConnectionValidator(c =>
                {
                    log.Info($"{c.ClientId} connection validator for c.Endpoint: {c.Endpoint}");
                    Console.WriteLine($"{c.ClientId} connection validator for c.Endpoint: {c.Endpoint}");

                    c.ReasonCode = MqttConnectReasonCode.Success;
                })
                .WithConnectionBacklog(100)
                .WithDefaultEndpointPort(1884);


            //start server
            var mqttServer = new MqttFactory().CreateMqttServer();
            mqttServer.StartAsync(optionsBuilder.Build()).Wait();

            log.Info($"Broker is Running: Host: {mqttServer.Options.DefaultEndpointOptions.BoundInterNetworkAddress} Port: {mqttServer.Options.DefaultEndpointOptions.Port}");
            Console.WriteLine($"Broker is Running: Host: {mqttServer.Options.DefaultEndpointOptions.BoundInterNetworkAddress} Port: {mqttServer.Options.DefaultEndpointOptions.Port}");
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();

            mqttServer.StopAsync().Wait();


        }
    }
}
