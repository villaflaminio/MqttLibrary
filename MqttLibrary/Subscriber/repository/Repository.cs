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
        public DbSet<MessageMqtt> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Mqtt.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageMqtt>().ToTable("MessageMqtt");
            
        }

    }
}
