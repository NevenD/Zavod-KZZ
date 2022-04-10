using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class NaturalChangePopulationConfiguration : IEntityTypeConfiguration<NaturalChangePopulation>
    {
        public void Configure(EntityTypeBuilder<NaturalChangePopulation> builder)
        {
            builder.ToTable("natural_change_population");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.LocalGovernmentAdministration).WithMany().HasForeignKey(x => x.LocalGovernmentAdministrationID);
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.LiveBirth).IsRequired();
            builder.Property(x => x.StillBirth).IsRequired(false);
            builder.Property(x => x.InfantDeath).IsRequired(false);
            builder.Property(x => x.Death).IsRequired();
        }
    }
}
