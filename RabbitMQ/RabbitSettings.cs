using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class RabbitSettings
    {
        public string HostName { get; set; } = string.Empty;
        public string QueueName { get; set; } = string.Empty;
    }
}
