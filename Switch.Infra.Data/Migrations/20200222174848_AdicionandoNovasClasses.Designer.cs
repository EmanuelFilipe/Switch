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
    [Migration("20200222174848_AdicionandoNovasClasses")]
    partial class AdicionandoNovasClasses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Switch.Domain.Entities.Amigo", b =>
                {
                    b.Property<int>("UsuarioId");

                    b.Property<int>("UsuarioAmigoId");

                    b.HasKey("UsuarioId", "UsuarioAmigoId");

                    b.HasIndex("UsuarioAmigoId");

                    b.ToTable("Amigos");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(600);

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UrlFoto")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Identificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Numero");

                    b.Property<int>("TipoDocumento");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Identificacao");
                });

            modelBuilder.Entity("Switch.Domain.Entities.InstituicaoEnsino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AnoFormacao");

                    b.Property<string>("Nome");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("InstituicoesEnsino");
                });

            modelBuilder.Entity("Switch.Domain.Entities.LocalTrabalho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAdmissao");

                    b.Property<DateTime?>("DataSaida");

                    b.Property<bool>("EmpresaAtual");

                    b.Property<string>("Nome");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("LocaisTrabalho");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Postagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<int>("GrupoId");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("UrlConteudo");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Postagens");
                });

            modelBuilder.Entity("Switch.Domain.Entities.ProcurandoPor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("ProcurandoPor");

                    b.HasData(
                        new { Id = 1, Descricao = "NaoEspecificado" },
                        new { Id = 2, Descricao = "Namoro" },
                        new { Id = 3, Descricao = "Amizade" },
                        new { Id = 4, Descricao = "RelacionamentoSerio" }
                    );
                });

            modelBuilder.Entity("Switch.Domain.Entities.StatusRelacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("StatusRelacionamento");

                    b.HasData(
                        new { Id = 1, Descricao = "NaoEspecificado" },
                        new { Id = 2, Descricao = "Solteiro" },
                        new { Id = 3, Descricao = "Casado" },
                        new { Id = 4, Descricao = "EmRelacionamentoSerio" }
                    );
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

                    b.Property<int?>("ProcurandoPorId");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int>("Sexo");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int?>("StatusRelacionamentoId");

                    b.Property<string>("UrlFoto")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.HasIndex("ProcurandoPorId");

                    b.HasIndex("StatusRelacionamentoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Switch.Domain.Entities.UsuarioGrupo", b =>
                {
                    b.Property<int>("UsuarioId");

                    b.Property<int>("GrupoId");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<bool>("EhAdministrador");

                    b.HasKey("UsuarioId", "GrupoId");

                    b.HasIndex("GrupoId");

                    b.ToTable("UsuarioGrupos");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Amigo", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Usuario", "UsuarioAmigo")
                        .WithMany()
                        .HasForeignKey("UsuarioAmigoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Switch.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Amigos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.Comentario", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Comentarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.Identificacao", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Identificacao")
                        .HasForeignKey("Switch.Domain.Entities.Identificacao", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.InstituicaoEnsino", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Usuario", "Usuario")
                        .WithMany("InstituicoesEnsino")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.LocalTrabalho", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Usuario", "Usuario")
                        .WithMany("LocaisTrabalho")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.Postagem", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Grupo", "Grupo")
                        .WithMany("Postagens")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Switch.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Postagens")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Switch.Domain.Entities.ProcurandoPor", "ProcurandoPor")
                        .WithMany()
                        .HasForeignKey("ProcurandoPorId");

                    b.HasOne("Switch.Domain.Entities.StatusRelacionamento", "StatusRelacionamento")
                        .WithMany()
                        .HasForeignKey("StatusRelacionamentoId");
                });

            modelBuilder.Entity("Switch.Domain.Entities.UsuarioGrupo", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Grupo", "Grupo")
                        .WithMany("UsuarioGrupos")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Switch.Domain.Entities.Usuario", "Usuario")
                        .WithMany("UsuarioGrupos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
