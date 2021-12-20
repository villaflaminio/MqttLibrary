﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MqttSubscriber.repository;

#nullable disable

namespace MqttSubscriber.Migrations
{
    [DbContext(typeof(Repository))]
    partial class RepositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MqttSubscriber.model.MessageMqtt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}