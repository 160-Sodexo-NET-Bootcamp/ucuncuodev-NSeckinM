﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220107214946_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContainerName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal(10,6)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal(10,6)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Containers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContainerName = "Cont1Antares",
                            Latitude = 39.97m,
                            Longitude = 32.8212m,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 2,
                            ContainerName = "Cont2TurgutOzalUni",
                            Latitude = 39.9721m,
                            Longitude = 32.8252m,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 3,
                            ContainerName = "Cont3AsagiEglence",
                            Latitude = 39.9721m,
                            Longitude = 32.8396m,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 4,
                            ContainerName = "Cont4RagipTParki",
                            Latitude = 39.9657m,
                            Longitude = 32.8121m,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 5,
                            ContainerName = "Cont5YenimahKaymakamlik",
                            Latitude = 32.8121m,
                            Longitude = 32.811m,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 6,
                            ContainerName = "Cont6IvedikMetro",
                            Latitude = 39.9576m,
                            Longitude = 32.8169m,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 7,
                            ContainerName = "Cont7DemetParki",
                            Latitude = 39.9669m,
                            Longitude = 32.7971m,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 8,
                            ContainerName = "Cont8NazimHikmetKültrMerkezi",
                            Latitude = 39.9606m,
                            Longitude = 32.7788m,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 9,
                            ContainerName = "Cont9Ankamall",
                            Latitude = 39.951862m,
                            Longitude = 32.832848m,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 10,
                            ContainerName = "Cont10tunalı",
                            Latitude = 39.909115m,
                            Longitude = 32.861881m,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 11,
                            ContainerName = "Cont11Kugulupark",
                            Latitude = 39.902428m,
                            Longitude = 32.860600m,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 12,
                            ContainerName = "Cont12Ulus",
                            Latitude = 39.941757m,
                            Longitude = 32.854733m,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 13,
                            ContainerName = "Cont13GenlikParki",
                            Latitude = 39.936897m,
                            Longitude = 32.853897m,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 14,
                            ContainerName = "Cont14Sihhiye",
                            Latitude = 39.929447m,
                            Longitude = 32.854996m,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 15,
                            ContainerName = "Cont15Kizilay",
                            Latitude = 39.9213m,
                            Longitude = 32.8506m,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 16,
                            ContainerName = "Cont16Guvenpark",
                            Latitude = 39.919548m,
                            Longitude = 32.853199m,
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 17,
                            ContainerName = "Cont17Mithatpasa",
                            Latitude = 39.920155m,
                            Longitude = 32.858952m,
                            VehicleId = 1
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VehicleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VehiclePlate")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            VehicleName = "Arac1",
                            VehiclePlate = "06ANK001"
                        },
                        new
                        {
                            Id = 2,
                            VehicleName = "Arac2",
                            VehiclePlate = "06ANK002"
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.Container", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Vehicle", "Vehicle")
                        .WithMany("Containers")
                        .HasForeignKey("VehicleId");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Vehicle", b =>
                {
                    b.Navigation("Containers");
                });
#pragma warning restore 612, 618
        }
    }
}
