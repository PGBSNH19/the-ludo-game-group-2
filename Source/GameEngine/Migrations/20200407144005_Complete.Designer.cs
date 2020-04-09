﻿// <auto-generated />
using GameEngine.Library.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameEngine.Library.Migrations
{
    [DbContext(typeof(LudoGameContext))]
    [Migration("20200407144005_Complete")]
    partial class Complete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameEngine.Library.Models.Pawn", b =>
                {
                    b.Property<int>("PawnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<bool>("HasReachedGoal")
                        .HasColumnType("bit");

                    b.Property<bool>("HasStarted")
                        .HasColumnType("bit");

                    b.Property<int>("PawnNumber")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PawnID");

                    b.HasIndex("UserID");

                    b.HasIndex("PawnNumber", "Color")
                        .IsUnique()
                        .HasFilter("[Color] IS NOT NULL");

                    b.ToTable("Pawns");
                });

            modelBuilder.Entity("GameEngine.Library.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameEngine.Library.Models.Pawn", b =>
                {
                    b.HasOne("GameEngine.Library.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
