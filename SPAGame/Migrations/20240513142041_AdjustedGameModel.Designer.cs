﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SPAGame.Data;

#nullable disable

namespace SPAGame.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240513142041_AdjustedGameModel")]
    partial class AdjustedGameModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SPAGame.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountEmail")
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("AccountName")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("AccountPassword")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("SPAGame.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<bool>("GameActive")
                        .HasColumnType("bit");

                    b.Property<int>("GameAttempts")
                        .HasColumnType("int");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameNumber")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("AccountId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SPAGame.Models.Highscore", b =>
                {
                    b.Property<int>("HighscoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HighscoreId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("HighscoreId");

                    b.HasIndex("AccountId");

                    b.ToTable("HighScores");
                });

            modelBuilder.Entity("SPAGame.Models.Profile", b =>
                {
                    b.Property<int>("AccountProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountProfileId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("GamesLost")
                        .HasColumnType("int");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("GamesWon")
                        .HasColumnType("int");

                    b.HasKey("AccountProfileId");

                    b.HasIndex("AccountId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("SPAGame.Models.Game", b =>
                {
                    b.HasOne("SPAGame.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("SPAGame.Models.Highscore", b =>
                {
                    b.HasOne("SPAGame.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("SPAGame.Models.Profile", b =>
                {
                    b.HasOne("SPAGame.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
