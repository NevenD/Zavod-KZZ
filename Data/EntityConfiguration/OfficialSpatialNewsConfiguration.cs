using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class OfficialSpatialNewsConfiguration : IEntityTypeConfiguration<OfficalSpatialNews>
    {
        public void Configure(EntityTypeBuilder<OfficalSpatialNews> builder)
        {
            builder.ToTable("official_spatial_news");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ShortName).HasMaxLength(50);
        }
    }
}
