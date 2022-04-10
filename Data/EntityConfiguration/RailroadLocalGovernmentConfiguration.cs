using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class RailroadLocalGovernmentConfiguration : IEntityTypeConfiguration<RailroadLocalGovernment>
    {
        public void Configure(EntityTypeBuilder<RailroadLocalGovernment> builder)
        {
            builder.ToTable("local_government_railroads");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.LocalGovernmentAdministration).WithMany().HasForeignKey(x => x.LocalGovernmentAdministrationID);
            builder.HasOne(x => x.Railroad).WithMany().HasForeignKey(x => x.RailroadID);
            builder.Property(x => x.RailroadLength).HasMaxLength(9).IsRequired();
        }
    }
}
