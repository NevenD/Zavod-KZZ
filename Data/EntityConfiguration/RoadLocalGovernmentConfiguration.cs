using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class RoadLocalGovernmentConfiguration : IEntityTypeConfiguration<RoadLocalGovernment>
    {
        public void Configure(EntityTypeBuilder<RoadLocalGovernment> builder)
        {
            builder.ToTable("local_government_roads");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.LocalGovernmentAdministration).WithMany().HasForeignKey(x => x.LocalGovernmentAdministrationID);
            builder.HasOne(x => x.Road).WithMany().HasForeignKey(x => x.RoadID);
            builder.Property(x => x.RoadLength).HasMaxLength(9).IsRequired();
        }
    }
}
