using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class RegulationConfiguration : IEntityTypeConfiguration<Regulation>
    {
        public void Configure(EntityTypeBuilder<Regulation> builder)
        {
            builder.ToTable("regulations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ShortName);
            builder.Property(x => x.Description);
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Remark);
            builder.Property(x => x.RegulationPublicationDate).IsRequired(false);
            builder.Property(x => x.RegulationEffectiveDate).IsRequired(false);
            builder.Property(x => x.DateArchived).IsRequired(false);
            builder.HasOne(x => x.RegulationType).WithMany().HasForeignKey(x => x.RegulationTypeID);
        }
    }
}
