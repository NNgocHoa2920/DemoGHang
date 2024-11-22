﻿// <auto-generated />
using System;
using DemoGHang.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoGHang.Migrations
{
    [DbContext(typeof(GHDbContex))]
    [Migration("20241122141558_he")]
    partial class he
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoGHang.Models.Account", b =>
                {
                    b.Property<Guid>("AccId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DemoGHang.Models.GHCT", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GioHangId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SanPhamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GioHangId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("GHCTs");
                });

            modelBuilder.Entity("DemoGHang.Models.GioHang", b =>
                {
                    b.Property<Guid>("GioHangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GioHangId");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("DemoGHang.Models.SanPham", b =>
                {
                    b.Property<Guid>("SanPhamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SanPhamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SanPhamId");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("DemoGHang.Models.GHCT", b =>
                {
                    b.HasOne("DemoGHang.Models.GioHang", "GioHang")
                        .WithMany("GHCTs")
                        .HasForeignKey("GioHangId");

                    b.HasOne("DemoGHang.Models.SanPham", "SanPham")
                        .WithMany("GHCTs")
                        .HasForeignKey("SanPhamId");

                    b.Navigation("GioHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("DemoGHang.Models.GioHang", b =>
                {
                    b.HasOne("DemoGHang.Models.Account", "Account")
                        .WithOne("GioHang")
                        .HasForeignKey("DemoGHang.Models.GioHang", "AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DemoGHang.Models.Account", b =>
                {
                    b.Navigation("GioHang");
                });

            modelBuilder.Entity("DemoGHang.Models.GioHang", b =>
                {
                    b.Navigation("GHCTs");
                });

            modelBuilder.Entity("DemoGHang.Models.SanPham", b =>
                {
                    b.Navigation("GHCTs");
                });
#pragma warning restore 612, 618
        }
    }
}
