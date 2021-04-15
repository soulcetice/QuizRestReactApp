﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations
{
    [DbContext(typeof(QuizDBContext))]
    [Migration("20200115115809_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.DQuestion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("correctAnswers")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("questionText")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("answers")
                        .HasColumnType("nvarchar(160)");

                    b.HasKey("id");

                    b.ToTable("DQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
