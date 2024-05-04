﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_Integrador_Prestamos.Context;

#nullable disable

namespace Proyecto_Integrador_Prestamos.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240504195638_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Inversionista", b =>
                {
                    b.Property<int>("idInversionista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idInversionista"), 1L, 1);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idSede")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("idInversionista");

                    b.HasIndex("idSede");

                    b.HasIndex("idUser");

                    b.ToTable("Inversionistas", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.JefePrestamista", b =>
                {
                    b.Property<int>("idJefePrestamista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idJefePrestamista"), 1L, 1);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idSede")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("idJefePrestamista");

                    b.HasIndex("idSede");

                    b.HasIndex("idUser");

                    b.ToTable("JefesPrestamistas", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestamista", b =>
                {
                    b.Property<int>("idPrestamista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPrestamista"), 1L, 1);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idSede")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("idPrestamista");

                    b.HasIndex("idSede");

                    b.HasIndex("idUser");

                    b.ToTable("Prestamistas", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestamo", b =>
                {
                    b.Property<int>("NroPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NroPrestamo"), 1L, 1);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("diasDuracion")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaFinVigencia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaIniVigencia")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPrestamista")
                        .HasColumnType("int");

                    b.Property<int>("idPrestatario")
                        .HasColumnType("int");

                    b.Property<decimal>("pagoDiario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NroPrestamo");

                    b.ToTable("Prestamo", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestatario", b =>
                {
                    b.Property<int>("IdPrestatario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestatario"), 1L, 1);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idSede")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("IdPrestatario");

                    b.HasIndex("idSede");

                    b.HasIndex("idUser");

                    b.ToTable("Prestatario", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Sede", b =>
                {
                    b.Property<int>("idSede")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idSede"), 1L, 1);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcionSede")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idSede");

                    b.ToTable("Sede", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUser"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creatorUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUser");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Inversionista", b =>
                {
                    b.HasOne("Proyecto_Integrador_Prestamos.Models.Sede", "Sede")
                        .WithMany()
                        .HasForeignKey("idSede")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Integrador_Prestamos.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sede");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.JefePrestamista", b =>
                {
                    b.HasOne("Proyecto_Integrador_Prestamos.Models.Sede", "Sede")
                        .WithMany()
                        .HasForeignKey("idSede")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Integrador_Prestamos.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sede");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestamista", b =>
                {
                    b.HasOne("Proyecto_Integrador_Prestamos.Models.Sede", "Sede")
                        .WithMany()
                        .HasForeignKey("idSede")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Integrador_Prestamos.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sede");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestatario", b =>
                {
                    b.HasOne("Proyecto_Integrador_Prestamos.Models.Sede", "Sede")
                        .WithMany()
                        .HasForeignKey("idSede")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Integrador_Prestamos.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sede");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}