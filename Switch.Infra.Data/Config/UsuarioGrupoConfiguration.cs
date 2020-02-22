using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Infra.Data.Config
{
    public class UsuarioGrupoConfiguration : IEntityTypeConfiguration<UsuarioGrupo>
    {
        public void Configure(EntityTypeBuilder<UsuarioGrupo> builder)
        {
            // por configuração
            builder.HasKey(u => new { u.UsuarioId, u.GrupoId });
            builder.Property(u => u.DataCriacao).IsRequired();
            builder.Property(u => u.EhAdministrador);
        }
    }
}
