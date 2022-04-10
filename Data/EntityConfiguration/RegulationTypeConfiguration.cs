using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class RegulationTypeConfiguration : IEntityTypeConfiguration<RegulationType>
    {
        public void Configure(EntityTypeBuilder<RegulationType> builder)
        {
            builder.ToTable("regulation_types");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();

        }
    }
}
