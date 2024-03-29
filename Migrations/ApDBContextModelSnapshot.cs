﻿// <auto-generated />
using System;
using BlazorAppMasterCrud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorAppMasterCrud.Migrations
{
    [DbContext(typeof(ApDBContext))]
    partial class ApDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorAppMasterCrud.Appointment", b =>
                {
                    b.Property<string>("Appointment_ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Appointment_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Appointment_ID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("BlazorAppMasterCrud.Service", b =>
                {
                    b.Property<string>("Service_ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Appointment_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service_Fee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Service_ID");

                    b.HasIndex("Appointment_ID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("BlazorAppMasterCrud.Service", b =>
                {
                    b.HasOne("BlazorAppMasterCrud.Appointment", "Appointment")
                        .WithMany("Service")
                        .HasForeignKey("Appointment_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("BlazorAppMasterCrud.Appointment", b =>
                {
                    b.Navigation("Service");
                });
#pragma warning restore 612, 618
        }
    }
}
