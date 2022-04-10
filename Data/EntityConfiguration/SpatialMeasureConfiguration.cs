using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class SpatialMeasureConfiguration : IEntityTypeConfiguration<SpatialMeasure>
    {
        public void Configure(EntityTypeBuilder<SpatialMeasure> builder)
        {
            builder.ToTable("spatial_measures");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
