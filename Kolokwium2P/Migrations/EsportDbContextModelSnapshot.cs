﻿// <auto-generated />
using System;
using Kolokwium2P.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolokwium2P.Migrations
{
    [DbContext(typeof(EsportDbContext))]
    partial class EsportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kolokwium2P.Model.Map", b =>
                {
                    b.Property<int>("MapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MapId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MapId");

                    b.ToTable("Maps");

                    b.HasData(
                        new
                        {
                            MapId = 1,
                            Name = "MapName1",
                            Type = "big"
                        },
                        new
                        {
                            MapId = 2,
                            Name = "MapName2",
                            Type = "medium"
                        },
                        new
                        {
                            MapId = 3,
                            Name = "MapName3",
                            Type = "small"
                        });
                });

            modelBuilder.Entity("Kolokwium2P.Model.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchId"));

                    b.Property<decimal>("BestRating")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.Property<int>("MapId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Team1Score")
                        .HasColumnType("int");

                    b.Property<int>("Team2Score")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("MapId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");

                    b.HasData(
                        new
                        {
                            MatchId = 1,
                            BestRating = 10.1m,
                            MapId = 1,
                            MatchDate = new DateTime(2025, 6, 10, 14, 24, 28, 314, DateTimeKind.Local).AddTicks(9369),
                            Team1Score = 1,
                            Team2Score = 2,
                            TournamentId = 1
                        },
                        new
                        {
                            MatchId = 2,
                            BestRating = 10.2m,
                            MapId = 2,
                            MatchDate = new DateTime(2025, 6, 10, 14, 24, 28, 314, DateTimeKind.Local).AddTicks(9374),
                            Team1Score = 1,
                            Team2Score = 2,
                            TournamentId = 2
                        },
                        new
                        {
                            MatchId = 3,
                            BestRating = 10.3m,
                            MapId = 3,
                            MatchDate = new DateTime(2025, 6, 10, 14, 24, 28, 314, DateTimeKind.Local).AddTicks(9376),
                            Team1Score = 1,
                            Team2Score = 2,
                            TournamentId = 3
                        });
                });

            modelBuilder.Entity("Kolokwium2P.Model.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            BirthDate = new DateTime(2025, 6, 10, 14, 24, 28, 314, DateTimeKind.Local).AddTicks(9261),
                            FirstName = "fn1",
                            LastName = "ln1"
                        },
                        new
                        {
                            PlayerId = 2,
                            BirthDate = new DateTime(2025, 6, 10, 14, 24, 28, 314, DateTimeKind.Local).AddTicks(9318),
                            FirstName = "fn2",
                            LastName = "ln2"
                        },
                        new
                        {
                            PlayerId = 3,
                            BirthDate = new DateTime(2025, 6, 10, 14, 24, 28, 314, DateTimeKind.Local).AddTicks(9320),
                            FirstName = "fn3",
                            LastName = "ln3"
                        });
                });

            modelBuilder.Entity("Kolokwium2P.Model.Player_Match", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("MVPs")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.HasKey("MatchId", "PlayerId");

                    b.ToTable("PlayerMatches");

                    b.HasData(
                        new
                        {
                            MatchId = 1,
                            PlayerId = 1,
                            MVPs = 1,
                            Rating = 4.3m
                        },
                        new
                        {
                            MatchId = 2,
                            PlayerId = 2,
                            MVPs = 2,
                            Rating = 10.2m
                        });
                });

            modelBuilder.Entity("Kolokwium2P.Model.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TournamentId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TournamentId");

                    b.ToTable("Tournaments");

                    b.HasData(
                        new
                        {
                            TournamentId = 1,
                            EndDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            Name = "tn1",
                            StartDate = new DateTime(2025, 6, 10, 14, 24, 28, 314, DateTimeKind.Local).AddTicks(9346)
                        },
                        new
                        {
                            TournamentId = 2,
                            EndDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            Name = "tn2",
                            StartDate = new DateTime(2025, 6, 10, 14, 24, 28, 314, DateTimeKind.Local).AddTicks(9349)
                        },
                        new
                        {
                            TournamentId = 3,
                            EndDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            Name = "tn3",
                            StartDate = new DateTime(2025, 6, 10, 14, 24, 28, 314, DateTimeKind.Local).AddTicks(9351)
                        });
                });

            modelBuilder.Entity("Kolokwium2P.Model.Match", b =>
                {
                    b.HasOne("Kolokwium2P.Model.Map", "Map")
                        .WithMany()
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2P.Model.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");

                    b.Navigation("Tournament");
                });
#pragma warning restore 612, 618
        }
    }
}
