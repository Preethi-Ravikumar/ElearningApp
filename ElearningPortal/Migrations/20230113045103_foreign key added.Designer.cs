﻿// <auto-generated />
using System;
using ElearningPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElearningPortal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230113045103_foreign key added")]
    partial class foreignkeyadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ElearningPortal.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CourseDuration")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StudentsEnrolled")
                        .HasColumnType("int");

                    b.Property<int?>("UserModelUserId")
                        .HasColumnType("int");

                    b.Property<byte>("isVerified")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("CourseId");

                    b.HasIndex("UserModelUserId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ElearningPortal.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("ElearningPortal.Models.Course", b =>
                {
                    b.HasOne("ElearningPortal.Models.UserModel", null)
                        .WithMany("Courses")
                        .HasForeignKey("UserModelUserId");
                });

            modelBuilder.Entity("ElearningPortal.Models.UserModel", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
