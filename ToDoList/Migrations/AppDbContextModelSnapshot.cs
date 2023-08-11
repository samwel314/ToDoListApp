﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.Data;

#nullable disable

namespace ToDoList.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoList.Models.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pirority")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("varchar(55)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ToDoList.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfRegister")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("varchar(55)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ToDoList.Models.EventTask", b =>
                {
                    b.HasBaseType("ToDoList.Models.Tasks");

                    b.Property<string>("Assigment")
                        .HasColumnType("varchar(55)");

                    b.Property<double?>("Budget")
                        .HasColumnType("float");

                    b.Property<string>("Event_Name")
                        .IsRequired()
                        .HasColumnType("varchar(55)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("varchar(55)");

                    b.ToTable("EventTasks", (string)null);
                });

            modelBuilder.Entity("ToDoList.Models.TravelTask", b =>
                {
                    b.HasBaseType("ToDoList.Models.Tasks");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("varchar(55)");

                    b.Property<string>("Transportation")
                        .HasColumnType("varchar(30)");

                    b.ToTable("TravelTasks", (string)null);
                });

            modelBuilder.Entity("ToDoList.Models.Tasks", b =>
                {
                    b.HasOne("ToDoList.Models.User", "User")
                        .WithMany("tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDoList.Models.EventTask", b =>
                {
                    b.HasOne("ToDoList.Models.Tasks", null)
                        .WithOne()
                        .HasForeignKey("ToDoList.Models.EventTask", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.Models.TravelTask", b =>
                {
                    b.HasOne("ToDoList.Models.Tasks", null)
                        .WithOne()
                        .HasForeignKey("ToDoList.Models.TravelTask", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToDoList.Models.User", b =>
                {
                    b.Navigation("tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
