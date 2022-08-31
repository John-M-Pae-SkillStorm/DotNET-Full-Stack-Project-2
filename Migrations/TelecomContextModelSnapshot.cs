﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TigerPhoneAPI.Contexts;

#nullable disable

namespace TigerPhoneAPI.Migrations
{
    [DbContext(typeof(TelecomContext))]
    partial class TelecomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TigerPhoneAPI.Models.Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"), 1L, 1);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("TigerPhoneAPI.Models.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"), 1L, 1);

                    b.Property<string>("PlanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanType")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("TigerPhoneAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TigerPhoneAPI.Models.Device", b =>
                {
                    b.HasOne("TigerPhoneAPI.Models.User", null)
                        .WithMany("Devices")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TigerPhoneAPI.Models.Plan", b =>
                {
                    b.HasOne("TigerPhoneAPI.Models.User", null)
                        .WithMany("Plans")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TigerPhoneAPI.Models.User", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("Plans");
                });
#pragma warning restore 612, 618
        }
    }
}
