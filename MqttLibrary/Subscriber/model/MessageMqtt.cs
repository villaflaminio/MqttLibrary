using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttSubscriber.model
{
    internal class MessageMqtt
    {
        public int Id { get; set; }
        public string Payload { get; set; }
        public string Topic { get; set; }
              
    }
}
