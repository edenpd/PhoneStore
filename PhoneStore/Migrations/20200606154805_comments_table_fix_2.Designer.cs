﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneStore.Data;

namespace PhoneStore.Migrations
{
    [DbContext(typeof(PhoneStoreContext))]
    [Migration("20200606154805_comments_table_fix_2")]
    partial class comments_table_fix_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneStore.Models.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhoneId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Posted")
                        .HasColumnType("datetime2");

                    b.Property<string>("SentBy")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.HasIndex("PhoneId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("PhoneStore.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhoneId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PhoneStore.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("PhoneStore.Models.Comment", b =>
                {
                    b.HasOne("PhoneStore.Models.Phone", "Phone")
                        .WithMany("Comments")
                        .HasForeignKey("PhoneId");
                });

            modelBuilder.Entity("PhoneStore.Models.Order", b =>
                {
                    b.HasOne("PhoneStore.Models.Phone", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId");
                });
#pragma warning restore 612, 618
        }
    }
}
