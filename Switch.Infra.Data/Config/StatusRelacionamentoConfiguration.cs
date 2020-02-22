using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Infra.Data.Config
{
    public class StatusRelacionamentoConfiguration : IEntityTypeConfiguration<StatusRelacionamento>
    {
        public void Configure(EntityTypeBuilder<StatusRelacionamento> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Descricao);

            // inserindo informações na tabela
            builder.HasData(
                new StatusRelacionamento() { Id = 1, Descricao = "NaoEspecificado" },
                new StatusRelacionamento() { Id = 2, Descricao = "Solteiro" },
                new StatusRelacionamento() { Id = 3, Descricao = "Casado"},
                new StatusRelacionamento() { Id = 4, Descricao = "EmRelacionamentoSerio"}
            );
        }
    }
}
