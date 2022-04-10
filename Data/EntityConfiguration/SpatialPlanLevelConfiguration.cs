using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class SpatialPlanLevelConfiguration : IEntityTypeConfiguration<SpatialPlanLevel>
    {
        public void Configure(EntityTypeBuilder<SpatialPlanLevel> builder)
        {
            builder.ToTable("spatial_plan_levels");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ShortName).IsRequired();
            builder.Property(x => x.FullName).HasColumnType("nvarchar(max)");
        }
    }
}
