﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Switch.Infra.Data.Context;

namespace Switch.Infra.Data.Migrations
{
    [DbContext(typeof(SwitchContext))]
    [Migration("20200216154623_AdicionadoClasseStatusRelacionamento")]
    partial class AdicionadoClasseStatusRelacionamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Switch.Domain.Entities.Postagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("Texto");

                    b.HasKey("Id");

                    b.ToTable("Postagens");
                });

            modelBuilder.Entity("Switch.Domain.Entities.StatusRelacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("StatusRelacionamento");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int>("Sexo");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("UrlFoto")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
