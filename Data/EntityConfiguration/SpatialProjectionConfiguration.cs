using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class SpatialProjectionConfiguration : IEntityTypeConfiguration<SpatialProjection>
    {
        public void Configure(EntityTypeBuilder<SpatialProjection> builder)
        {
            builder.ToTable("spatial_projections");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.EnglishName).HasColumnType("nvarchar(max)");
            builder.Property(x => x.DescriptionOverview).HasColumnType("nvarchar(max)");
            builder.Property(x => x.ShortName).HasMaxLength(20);
            builder.Property(x => x.EpsgCode).HasMaxLength(20);
            builder.Property(x => x.Description).HasColumnType("nvarchar(max)");
        }
    }
}
