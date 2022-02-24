// <auto-generated />
using System;
using LeaderboardBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeaderboardBackend.Migrations
{
	[DbContext(typeof(ApplicationContext))]
	partial class ApplicationContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "6.0.1")
				.HasAnnotation("Relational:MaxIdentifierLength", 63);

			NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

			modelBuilder.Entity("LeaderboardBackend.Models.Leaderboard", b =>
				{
					b.Property<long>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("bigint")
						.HasColumnName("id");

					NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

					b.Property<string>("Name")
						.IsRequired()
						.HasColumnType("text")
						.HasColumnName("name");

					b.Property<string>("Rules")
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
#pragma warning restore 612, 618
		}
	}
}