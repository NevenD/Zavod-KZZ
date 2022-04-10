using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class DocumentStatusZaraConfiguration : IEntityTypeConfiguration<DocumentStatusZara>
    {
        public void Configure(EntityTypeBuilder<DocumentStatusZara> builder)
        {
            builder.ToTable("document_zara_status");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
