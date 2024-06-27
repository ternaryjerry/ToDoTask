﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoTask;

#nullable disable

namespace ToDoTask.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20240623231301_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ToDoTask.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "Work",
                            Name = "Work"
                        },
                        new
                        {
                            CategoryId = "Home",
                            Name = "Home"
                        },
                        new
                        {
                            CategoryId = "Excercise",
                            Name = "Excercise"
                        },
                        new
                        {
                            CategoryId = "Shopping",
                            Name = "Shopping"
                        },
                        new
                        {
                            CategoryId = "Meeting",
                            Name = "Meeting"
                        });
                });

            modelBuilder.Entity("ToDoTask.Priority", b =>
                {
                    b.Property<string>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PriorityId");

                    b.ToTable("Priorities");

                    b.HasData(
                        new
                        {
                            PriorityId = "High",
                            Name = "High"
                        },
                        new
                        {
                            PriorityId = "Medium",
                            Name = "Medium"
                        },
                        new
                        {
                            PriorityId = "Low",
                            Name = "Low"
                        });
                });

            modelBuilder.Entity("ToDoTask.Status", b =>
                {
                    b.Property<string>("StatusId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = "Open",
                            Name = "Open"
                        },
                        new
                        {
                            StatusId = "Completed",
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("ToDoTask.TaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PriorityId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("StatusId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = "Work",
                            Description = "Finish ToDo Task",
                            DueDate = new DateTime(2024, 6, 26, 19, 13, 0, 254, DateTimeKind.Local).AddTicks(2330),
                            PriorityId = "High",
                            StatusId = "Open"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = "Work",
                            Description = "Finish ToDo Task",
                            DueDate = new DateTime(2024, 6, 26, 19, 13, 0, 254, DateTimeKind.Local).AddTicks(2400),
                            PriorityId = "High",
                            StatusId = "Open"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = "Work",
                            Description = "Finish ToDo Task",
                            DueDate = new DateTime(2024, 6, 26, 19, 13, 0, 254, DateTimeKind.Local).AddTicks(2400),
                            PriorityId = "High",
                            StatusId = "Open"
                        });
                });

            modelBuilder.Entity("ToDoTask.TaskModel", b =>
                {
                    b.HasOne("ToDoTask.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoTask.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoTask.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Priority");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
