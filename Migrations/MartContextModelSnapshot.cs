﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SieuThi.Repository;

namespace SieuThi.Migrations
{
    [DbContext(typeof(MartContext))]
    partial class MartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SieuThi.Models.Product", b =>
                {
                    b.Property<int>("Masp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Donvi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GiaBan")
                        .HasColumnType("int");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tensp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Masp");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SieuThi.Models.SalesManagement", b =>
                {
                    b.Property<int>("Mahoadon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Manv_FKManv")
                        .HasColumnType("int");

                    b.Property<int?>("Masp_FKMasp")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ngay")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoLuong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tensp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TriGia")
                        .HasColumnType("int");

                    b.HasKey("Mahoadon");

                    b.HasIndex("Manv_FKManv");

                    b.HasIndex("Masp_FKMasp");

                    b.ToTable("SalesManagements");
                });

            modelBuilder.Entity("SieuThi.Models.SalesReport", b =>
                {
                    b.Property<int>("MaBaoCao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DoanhThu")
                        .HasColumnType("int");

                    b.Property<int?>("Manv_FKManv")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ngay")
                        .HasColumnType("datetime2");

                    b.HasKey("MaBaoCao");

                    b.HasIndex("Manv_FKManv");

                    b.ToTable("SalesReports");
                });

            modelBuilder.Entity("SieuThi.Models.Staff", b =>
                {
                    b.Property<int>("Manv")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Luong")
                        .HasColumnType("int");

                    b.Property<string>("MotaCV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tennv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Manv");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("SieuThi.Models.Stored", b =>
                {
                    b.Property<int>("MaPhieuNhap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GiaNhap")
                        .HasColumnType("int");

                    b.Property<int?>("Masp_FKMasp")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("Tensp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaPhieuNhap");

                    b.HasIndex("Masp_FKMasp");

                    b.ToTable("Storeds");
                });

            modelBuilder.Entity("SieuThi.Models.SalesManagement", b =>
                {
                    b.HasOne("SieuThi.Models.Staff", "Manv_FK")
                        .WithMany("SalesManagements")
                        .HasForeignKey("Manv_FKManv");

                    b.HasOne("SieuThi.Models.Product", "Masp_FK")
                        .WithMany("SalesManagements")
                        .HasForeignKey("Masp_FKMasp");

                    b.Navigation("Manv_FK");

                    b.Navigation("Masp_FK");
                });

            modelBuilder.Entity("SieuThi.Models.SalesReport", b =>
                {
                    b.HasOne("SieuThi.Models.Staff", "Manv_FK")
                        .WithMany("SalesReports")
                        .HasForeignKey("Manv_FKManv");

                    b.Navigation("Manv_FK");
                });

            modelBuilder.Entity("SieuThi.Models.Stored", b =>
                {
                    b.HasOne("SieuThi.Models.Product", "Masp_FK")
                        .WithMany("Storeds")
                        .HasForeignKey("Masp_FKMasp");

                    b.Navigation("Masp_FK");
                });

            modelBuilder.Entity("SieuThi.Models.Product", b =>
                {
                    b.Navigation("SalesManagements");

                    b.Navigation("Storeds");
                });

            modelBuilder.Entity("SieuThi.Models.Staff", b =>
                {
                    b.Navigation("SalesManagements");

                    b.Navigation("SalesReports");
                });
#pragma warning restore 612, 618
        }
    }
}
