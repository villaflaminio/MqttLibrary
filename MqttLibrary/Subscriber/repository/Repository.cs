using Microsoft.EntityFrameworkCore;
using MqttSubscriber.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttSubscriber.repository
{
    internal class Repository : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // connect to mysql with connection string from app settings
            var connectionString = "server=localhost; port=3307; database=mqtt; user=root; password=flaminio; Persist Security Info=False; Connect Timeout=300"; //Configuration.GetConnectionString("ConnectionStringDatabase");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            // var connectionString = "server=localhost; port=3307; database=repository; user=root; password=flaminio; Persist Security Info=False; Connect Timeout=300";
        }
        public DbSet<MessageMqtt> Messages { get; set; }

    }
}
