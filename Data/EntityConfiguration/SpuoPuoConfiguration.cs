using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class SpuoPuoConfiguration : IEntityTypeConfiguration<SpuoPuoDocument>
    {
        public void Configure(EntityTypeBuilder<SpuoPuoDocument> builder)
        {
            builder.ToTable("spuo_puo_documents");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(max)");

        }
    }
}
