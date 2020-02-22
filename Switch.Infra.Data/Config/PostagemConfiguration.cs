using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Infra.Data.Config
{
    public class PostagemConfiguration : IEntityTypeConfiguration<Postagem>
    {
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DataPublicacao).IsRequired();
            builder.Property(p => p.Texto).IsRequired().HasMaxLength(400);
            // uma postagem pode ter somente um usuario e um usuario pode ter várias postagens
            builder.HasOne(p => p.Usuario).WithMany(p => p.Postagens);
            
        }
    }
}
