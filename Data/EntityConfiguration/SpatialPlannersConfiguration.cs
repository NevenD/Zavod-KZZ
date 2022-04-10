using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class SpatialPlannersConfiguration : IEntityTypeConfiguration<SpatialPlanner>
    {
        public void Configure(EntityTypeBuilder<SpatialPlanner> builder)
        {
            builder.ToTable("spatial_planners");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Location).HasColumnType("nvarchar(max)");
            builder.Property(x => x.Address).HasColumnType("nvarchar(max)");
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(200);
        }
    }
}
