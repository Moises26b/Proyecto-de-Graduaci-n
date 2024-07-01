﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models;

#nullable disable

namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Migrations
{
    [DbContext(typeof(ProyectoContext))]
    [Migration("20240616024010_UsuarioRoles")]
    partial class UsuarioRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstadoRol")
                        .HasColumnType("bit");

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models.Sesion", b =>
                {
                    b.Property<string>("IdSesion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdSesion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Sesiones");
                });

            modelBuilder.Entity("Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<bool>("EstadoUsuario")
                        .HasColumnType("bit");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("UltimaConexion")
                        .HasColumnType("date");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models.UsuarioRol", b =>
                {
                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("UsuarioRoles");
                });

            modelBuilder.Entity("Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models.Sesion", b =>
                {
                    b.HasOne("Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models.UsuarioRol", b =>
                {
                    b.HasOne("Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
