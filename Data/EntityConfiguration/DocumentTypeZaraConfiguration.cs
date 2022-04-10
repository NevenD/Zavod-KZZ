using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class DocumentTypeZaraConfiguration : IEntityTypeConfiguration<DocumentTypeZara>
    {
        public void Configure(EntityTypeBuilder<DocumentTypeZara> builder)
        {
            builder.ToTable("document_zara_types");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.ShortName);
        }
    }
    
}
