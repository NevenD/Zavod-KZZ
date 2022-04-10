using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class RoadConfiguration : IEntityTypeConfiguration<Road>
    {
        public void Configure(EntityTypeBuilder<Road> builder)
        {
            builder.ToTable("sorted_roads");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).HasMaxLength(300).IsRequired();
            builder.HasOne(x => x.RoadCategory).WithMany().HasForeignKey(x => x.RoadCategoryID);
            builder.Property(x => x.Description).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.DigitalOrthophotoLength).HasMaxLength(9); ;
            builder.Property(x => x.SpatialNewslength).HasMaxLength(9).IsRequired();
            builder.Property(x => x.ReconstructionDate).IsRequired(false);
            builder.Property(x => x.ReconstructionDescription).HasColumnType("nvarchar(max)");
        }
    }
}
