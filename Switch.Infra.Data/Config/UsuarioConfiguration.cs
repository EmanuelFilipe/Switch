﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Infra.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).HasMaxLength(400).IsRequired();
            builder.Property(u => u.SobreNome).HasMaxLength(400).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(400).IsRequired();
            builder.Property(u => u.Senha).HasMaxLength(400).IsRequired();
            builder.Property(u => u.Sexo).IsRequired();
            builder.Property(u => u.UrlFoto).HasMaxLength(400).IsRequired();
            builder.Property(u => u.DataNascimento).IsRequired();

            // 1 x 1 -- parece que este precisa informar o FK
            // Usuario tem uma Identifiacao || e Identificacao tem um Usuario
            builder.HasOne(u => u.Identificacao)
                    .WithOne(i => i.Usuario)
                    .HasForeignKey<Identificacao>(i => i.UsuarioId);

            // N x 1
            // Usuario tem muitos Comentarios || Comentario tem um Usuario
            builder.HasMany(u => u.Comentarios).WithOne(c => c.Usuario);
            builder.HasMany(u => u.Amigos).WithOne(a => a.Usuario);
            //builder.HasMany(u => u.Postagens).WithOne(p => p.Usuario);
            //builder.HasMany(u => u.UsuarioGrupos).WithOne(p => p.Usuario);
            //builder.HasOne(u => u.StatusRelacionamento);
            //builder.HasOne(u => u.ProcurandoPor);


        }
    }
}
