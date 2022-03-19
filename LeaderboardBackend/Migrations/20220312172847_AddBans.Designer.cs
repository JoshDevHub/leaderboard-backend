﻿// <auto-generated />
using System;
using LeaderboardBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeaderboardBackend.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220312172847_AddBans")]
    partial class AddBans
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LeaderboardBackend.Models.Ban", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("id");

                    b.Property<Guid>("BannedUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("banned_user_id");

                    b.Property<Guid>("BanningUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("banning_user_id");

                    b.Property<decimal?>("LeaderboardId")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("leaderboard_id");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("reason");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("time");

                    b.HasKey("Id")
                        .HasName("pk_bans");

                    b.HasIndex("BannedUserId")
                        .HasDatabaseName("ix_bans_banned_user_id");

                    b.HasIndex("BanningUserId")
                        .HasDatabaseName("ix_bans_banning_user_id");

                    b.HasIndex("LeaderboardId")
                        .HasDatabaseName("ix_bans_leaderboard_id");

                    b.ToTable("bans", (string)null);
                });

            modelBuilder.Entity("LeaderboardBackend.Models.Leaderboard", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("rules");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("slug");

                    b.HasKey("Id")
                        .HasName("pk_leaderboards");

                    b.ToTable("leaderboards", (string)null);
                });

            modelBuilder.Entity("LeaderboardBackend.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("LeaderboardBackend.Models.Ban", b =>
                {
                    b.HasOne("LeaderboardBackend.Models.User", "BannedUser")
                        .WithMany("BansReceived")
                        .HasForeignKey("BannedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bans_users_banned_user_id");

                    b.HasOne("LeaderboardBackend.Models.User", "BanningUser")
                        .WithMany("BansGiven")
                        .HasForeignKey("BanningUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bans_users_banning_user_id");

                    b.HasOne("LeaderboardBackend.Models.Leaderboard", "Leaderboard")
                        .WithMany("Bans")
                        .HasForeignKey("LeaderboardId")
                        .HasConstraintName("fk_bans_leaderboards_leaderboard_id");

                    b.Navigation("BannedUser");

                    b.Navigation("BanningUser");

                    b.Navigation("Leaderboard");
                });

            modelBuilder.Entity("LeaderboardBackend.Models.Leaderboard", b =>
                {
                    b.Navigation("Bans");
                });

            modelBuilder.Entity("LeaderboardBackend.Models.User", b =>
                {
                    b.Navigation("BansGiven");

                    b.Navigation("BansReceived");
                });
#pragma warning restore 612, 618
        }
    }
}