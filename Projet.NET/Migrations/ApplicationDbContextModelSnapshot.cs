﻿// <auto-generated />
using System;
using Infrastructure.Data.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Shared.ApiModels.MaintenanceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MileageMaintenance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VehicleModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WorksPerformed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("MaintenanceModel");
                });

            modelBuilder.Entity("Shared.ApiModels.ModelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaintenanceFrequency")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ModelModel");
                });

            modelBuilder.Entity("Shared.ApiModels.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Energie")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Matriculation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Mileage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModelModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ModelModelId");

                    b.ToTable("VehicleModel");
                });

            modelBuilder.Entity("Shared.ApiModels.MaintenanceModel", b =>
                {
                    b.HasOne("Shared.ApiModels.VehicleModel", null)
                        .WithMany("Maintenance")
                        .HasForeignKey("VehicleModelId");
                });

            modelBuilder.Entity("Shared.ApiModels.VehicleModel", b =>
                {
                    b.HasOne("Shared.ApiModels.ModelModel", null)
                        .WithMany("Vehicle")
                        .HasForeignKey("ModelModelId");
                });

            modelBuilder.Entity("Shared.ApiModels.ModelModel", b =>
                {
                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Shared.ApiModels.VehicleModel", b =>
                {
                    b.Navigation("Maintenance");
                });
#pragma warning restore 612, 618
        }
    }
}
