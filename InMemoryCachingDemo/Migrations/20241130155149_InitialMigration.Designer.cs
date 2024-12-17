﻿// <auto-generated />
using InMemoryCachingDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InMemoryCachingDemo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241130155149_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InMemoryCachingDemo.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Name = "Los Angeles",
                            StateId = 1
                        },
                        new
                        {
                            CityId = 2,
                            Name = "San Francisco",
                            StateId = 1
                        },
                        new
                        {
                            CityId = 3,
                            Name = "Houston",
                            StateId = 2
                        },
                        new
                        {
                            CityId = 4,
                            Name = "Dallas",
                            StateId = 2
                        },
                        new
                        {
                            CityId = 5,
                            Name = "Vancouver",
                            StateId = 3
                        },
                        new
                        {
                            CityId = 6,
                            Name = "Toronto",
                            StateId = 4
                        },
                        new
                        {
                            CityId = 7,
                            Name = "London",
                            StateId = 5
                        },
                        new
                        {
                            CityId = 8,
                            Name = "Mumbai",
                            StateId = 6
                        },
                        new
                        {
                            CityId = 9,
                            Name = "Pune",
                            StateId = 6
                        });
                });

            modelBuilder.Entity("InMemoryCachingDemo.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "India"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "United States"
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "Canada"
                        },
                        new
                        {
                            CountryId = 4,
                            Name = "United Kingdom"
                        });
                });

            modelBuilder.Entity("InMemoryCachingDemo.Models.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            StateId = 1,
                            CountryId = 2,
                            Name = "California"
                        },
                        new
                        {
                            StateId = 2,
                            CountryId = 2,
                            Name = "Texas"
                        },
                        new
                        {
                            StateId = 3,
                            CountryId = 3,
                            Name = "British Columbia"
                        },
                        new
                        {
                            StateId = 4,
                            CountryId = 3,
                            Name = "Ontario"
                        },
                        new
                        {
                            StateId = 5,
                            CountryId = 4,
                            Name = "England"
                        },
                        new
                        {
                            StateId = 6,
                            CountryId = 1,
                            Name = "Maharashtra"
                        },
                        new
                        {
                            StateId = 7,
                            CountryId = 1,
                            Name = "Delhi"
                        });
                });

            modelBuilder.Entity("InMemoryCachingDemo.Models.City", b =>
                {
                    b.HasOne("InMemoryCachingDemo.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("InMemoryCachingDemo.Models.State", b =>
                {
                    b.HasOne("InMemoryCachingDemo.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("InMemoryCachingDemo.Models.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("InMemoryCachingDemo.Models.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
