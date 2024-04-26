﻿// <auto-generated />
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
    [Migration("20240426012012_v7")]
    partial class v7
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

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sede")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idInversionista");

                    b.ToTable("Inversionistas", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.JefePrestamista", b =>
                {
                    b.Property<int>("idJefePrestamista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idJefePrestamista"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InversionistaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sede")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idJefePrestamista");

                    b.HasIndex("InversionistaId");

                    b.ToTable("JefesPrestamistas", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestamista", b =>
                {
                    b.Property<int>("idPrestamista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPrestamista"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JefePrestamistaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sede")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPrestamista");

                    b.HasIndex("JefePrestamistaId");

                    b.ToTable("Prestamistas", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestamo", b =>
                {
                    b.Property<int>("NroPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NroPrestamo"), 1L, 1);

                    b.Property<int>("Cuotas")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPrestamista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPrestatario")
                        .HasColumnType("int");

                    b.Property<decimal>("Importe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Moneda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sede")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NroPrestamo");

                    b.ToTable("Prestamo", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestatario", b =>
                {
                    b.Property<int>("IdPrestatario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestatario"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrestamistaId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPrestatario");

                    b.HasIndex("PrestamistaId");

                    b.ToTable("Prestatario", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Sede", b =>
                {
                    b.Property<int>("idSede")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idSede"), 1L, 1);

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

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
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

                    b.HasKey("idUser");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.JefePrestamista", b =>
                {
                    b.HasOne("Proyecto_Integrador_Prestamos.Models.Inversionista", "Inversionista")
                        .WithMany("JefesPrestamistas")
                        .HasForeignKey("InversionistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inversionista");
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestamista", b =>
                {
                    b.HasOne("Proyecto_Integrador_Prestamos.Models.JefePrestamista", "JefePrestamista")
                        .WithMany("Prestamistas")
                        .HasForeignKey("JefePrestamistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JefePrestamista");
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestatario", b =>
                {
                    b.HasOne("Proyecto_Integrador_Prestamos.Models.Prestamista", "Prestamista")
                        .WithMany("Prestatarios")
                        .HasForeignKey("PrestamistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestamista");
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Inversionista", b =>
                {
                    b.Navigation("JefesPrestamistas");
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.JefePrestamista", b =>
                {
                    b.Navigation("Prestamistas");
                });

            modelBuilder.Entity("Proyecto_Integrador_Prestamos.Models.Prestamista", b =>
                {
                    b.Navigation("Prestatarios");
                });
#pragma warning restore 612, 618
        }
    }
}
