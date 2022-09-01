﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TigerPhoneAPI.Contexts;

#nullable disable

namespace TigerPhoneAPI.Migrations
{
    [DbContext(typeof(TelecomContext))]
    [Migration("20220901195313_1Sep")]
    partial class _1Sep
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlanId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeviceId");

                    b.HasIndex("PlanId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("TigerPhoneAPI.Models.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"), 1L, 1);

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

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TigerPhoneAPI.Models.Device", b =>
                {
                    b.HasOne("TigerPhoneAPI.Models.Plan", null)
                        .WithMany("Devices")
                        .HasForeignKey("PlanId");
                });

            modelBuilder.Entity("TigerPhoneAPI.Models.Plan", b =>
                {
                    b.HasOne("TigerPhoneAPI.Models.User", null)
                        .WithMany("Plans")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TigerPhoneAPI.Models.Plan", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("TigerPhoneAPI.Models.User", b =>
                {
                    b.Navigation("Plans");
                });
#pragma warning restore 612, 618
        }
    }
}