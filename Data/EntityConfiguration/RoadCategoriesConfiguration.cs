using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class RoadCategoriesConfiguration : IEntityTypeConfiguration<RoadCategory>
    {
        public void Configure(EntityTypeBuilder<RoadCategory> builder) 
        {
            builder.ToTable("road_categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
        }
    }
}
