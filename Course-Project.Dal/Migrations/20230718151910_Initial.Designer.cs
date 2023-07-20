﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Course_Project.Dal.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Course_Project.Dal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230718151910_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Course_Project.Domain.Entities.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("ImageFilename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<byte>("Topic")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.CustomField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("CustomFields");
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomFieldValues")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Likes")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Tags")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CollectionId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 7, 18, 15, 19, 10, 422, DateTimeKind.Utc).AddTicks(5323),
                            Email = "sm.ashurov7@gmail.com",
                            IsAdmin = true,
                            IsBlocked = false,
                            IsDeleted = false,
                            Password = "2005",
                            Username = "Safarmurod"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 7, 18, 15, 19, 10, 422, DateTimeKind.Utc).AddTicks(5327),
                            Email = "Shahribonu@gmail.com",
                            IsAdmin = true,
                            IsBlocked = false,
                            IsDeleted = false,
                            Password = "IELTS7",
                            Username = "Shahribonu"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 7, 18, 15, 19, 10, 422, DateTimeKind.Utc).AddTicks(5328),
                            Email = "Akmaliygmail.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            IsDeleted = false,
                            Password = "1234",
                            Username = "AkmalAziz"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 7, 18, 15, 19, 10, 422, DateTimeKind.Utc).AddTicks(5328),
                            Email = "Sasha@gmail.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            IsDeleted = false,
                            Password = "123",
                            Username = "Sasha"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 7, 18, 15, 19, 10, 422, DateTimeKind.Utc).AddTicks(5329),
                            Email = "Antoniy3@gmail.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            IsDeleted = false,
                            Password = "1232",
                            Username = "Antonio"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2023, 7, 18, 15, 19, 10, 422, DateTimeKind.Utc).AddTicks(5329),
                            Email = "mark@gmail.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            IsDeleted = false,
                            Password = "122",
                            Username = "MarkZuckerberg"
                        });
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.Collection", b =>
                {
                    b.HasOne("Course_Project.Domain.Entities.User", "Owner")
                        .WithMany("Collections")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.Comment", b =>
                {
                    b.HasOne("Course_Project.Domain.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Project.Domain.Entities.Item", "Item")
                        .WithMany("Comments")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.CustomField", b =>
                {
                    b.HasOne("Course_Project.Domain.Entities.Collection", "Collection")
                        .WithMany("CustomFields")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.Item", b =>
                {
                    b.HasOne("Course_Project.Domain.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Project.Domain.Entities.Collection", "Collection")
                        .WithMany("Items")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.Collection", b =>
                {
                    b.Navigation("CustomFields");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.Item", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Course_Project.Domain.Entities.User", b =>
                {
                    b.Navigation("Collections");
                });
#pragma warning restore 612, 618
        }
    }
}