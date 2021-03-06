﻿// <auto-generated />
using DemoEFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DemoEFCore.Repository.Migrations
{
    [DbContext(typeof(CommonContext))]
    [Migration("20180131010443_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoEFCore.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("Manufacturer");

                    b.Property<decimal>("Price");

                    b.Property<Guid>("SeriesId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.Property<string>("VehicleName");

                    b.Property<string>("Year");

                    b.Property<bool>("isOnly");

                    b.HasKey("Id");

                    b.HasIndex("SeriesId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("DemoEFCore.Models.VehicleSeries", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("SeriesName");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.ToTable("VehicleSeries");
                });

            modelBuilder.Entity("DemoEFCore.Models.Vehicle", b =>
                {
                    b.HasOne("DemoEFCore.Models.VehicleSeries", "VehicleSeries")
                        .WithMany("Vehicles")
                        .HasForeignKey("SeriesId")
                        .HasConstraintName("FK_Vehicle_VehicleSeries")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
