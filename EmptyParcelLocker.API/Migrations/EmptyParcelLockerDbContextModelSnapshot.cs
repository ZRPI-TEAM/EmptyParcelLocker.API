﻿// <auto-generated />
using System;
using EmptyParcelLocker.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmptyParcelLocker.API.Migrations
{
    [DbContext(typeof(EmptyParcelLockerDbContext))]
    partial class EmptyParcelLockerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmptyParcelLocker.API.Data.Models.Coordinates", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("EmptyParcelLocker.API.Data.Models.Locker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsEmpty")
                        .HasColumnType("bit");

                    b.Property<Guid>("LockerTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ParcelLockerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParcelLockerId");

                    b.ToTable("Lockers");
                });

            modelBuilder.Entity("EmptyParcelLocker.API.Data.Models.LockerType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaxHeight")
                        .HasColumnType("int");

                    b.Property<int>("MaxLength")
                        .HasColumnType("int");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.Property<int>("MaxWidth")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LockerTypes");
                });

            modelBuilder.Entity("EmptyParcelLocker.API.Data.Models.ParcelLocker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CoordinatesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoordinatesId");

                    b.ToTable("ParcelLockers");
                });

            modelBuilder.Entity("EmptyParcelLocker.API.Data.Models.Locker", b =>
                {
                    b.HasOne("EmptyParcelLocker.API.Data.Models.ParcelLocker", null)
                        .WithMany("Lockers")
                        .HasForeignKey("ParcelLockerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmptyParcelLocker.API.Data.Models.ParcelLocker", b =>
                {
                    b.HasOne("EmptyParcelLocker.API.Data.Models.Coordinates", "Coordinates")
                        .WithMany()
                        .HasForeignKey("CoordinatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinates");
                });

            modelBuilder.Entity("EmptyParcelLocker.API.Data.Models.ParcelLocker", b =>
                {
                    b.Navigation("Lockers");
                });
#pragma warning restore 612, 618
        }
    }
}
