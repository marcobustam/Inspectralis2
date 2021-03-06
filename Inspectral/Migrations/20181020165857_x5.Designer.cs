﻿// <auto-generated />
using System;
using Inspectral.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inspectral.Migrations
{
    [DbContext(typeof(InspectralContext))]
    [Migration("20181020165857_x5")]
    partial class x5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inspectral.Models.Individualizacion", b =>
                {
                    b.Property<int>("IndividualizacionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Capacidad");

                    b.Property<string>("Comprador");

                    b.Property<string>("Fabricante");

                    b.Property<DateTime>("FechaFabricación");

                    b.Property<DateTime>("FechaInicioInspeccion");

                    b.Property<DateTime>("FechaTerminoInspeccion");

                    b.Property<DateTime>("HoraInicio");

                    b.Property<DateTime>("HoraTermino");

                    b.Property<string>("Material");

                    b.Property<string>("NormaReferencia");

                    b.Property<string>("Tanque");

                    b.Property<string>("TipoTanque");

                    b.HasKey("IndividualizacionID");

                    b.ToTable("Individualizacion");
                });

            modelBuilder.Entity("Inspectral.Models.Informe", b =>
                {
                    b.Property<int>("InformeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoSEC");

                    b.Property<string>("Descripcion");

                    b.Property<int>("IndividualizacionID");

                    b.Property<string>("Nombre");

                    b.Property<string>("Titulo");

                    b.HasKey("InformeID");

                    b.HasIndex("IndividualizacionID");

                    b.ToTable("Informe");
                });

            modelBuilder.Entity("Inspectral.Models.Seccion", b =>
                {
                    b.Property<int>("SeccionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenido");

                    b.Property<int>("InformeID");

                    b.Property<int>("Orden");

                    b.Property<string>("Titulo");

                    b.HasKey("SeccionID");

                    b.HasIndex("InformeID");

                    b.ToTable("Seccion");
                });

            modelBuilder.Entity("Inspectral.Models.Informe", b =>
                {
                    b.HasOne("Inspectral.Models.Individualizacion", "Individualizacion")
                        .WithMany()
                        .HasForeignKey("IndividualizacionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inspectral.Models.Seccion", b =>
                {
                    b.HasOne("Inspectral.Models.Informe")
                        .WithMany("Secciones")
                        .HasForeignKey("InformeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
