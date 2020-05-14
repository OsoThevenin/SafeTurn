﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SafeTurn.Persistence.DataAccess;

namespace SafeTurn.Persistence.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200514083116_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SafeTurn.Domain.Shops.Shop", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("FridayEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("FridayStart")
                        .HasColumnType("time");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MinutesForTurn")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("MondayEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("MondayStart")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("SaturdayEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("SaturdayStart")
                        .HasColumnType("time");

                    b.Property<int>("SimultaneousTurns")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("SundayEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("SundayStart")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("ThursdayEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("ThursdayStart")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TuesdayEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TuesdayStart")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("WednesdayEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("WednesdayStart")
                        .HasColumnType("time");

                    b.HasKey("Code");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("SafeTurn.Domain.Turns.Turn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("ShopCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ShopCode");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("SafeTurn.Domain.Users.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("RemoteIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("SafeTurn.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdentityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SafeTurn.Domain.Turns.Turn", b =>
                {
                    b.HasOne("SafeTurn.Domain.Shops.Shop", "Shop")
                        .WithMany("Turns")
                        .HasForeignKey("ShopCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SafeTurn.Domain.Users.RefreshToken", b =>
                {
                    b.HasOne("SafeTurn.Domain.Users.User", null)
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
