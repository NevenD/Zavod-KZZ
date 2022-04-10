using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{

    public class LocalGovernmentSettlementConfiguration : IEntityTypeConfiguration<LocalGovernmentSettlement>
    {

        public void Configure(EntityTypeBuilder<LocalGovernmentSettlement> builder)
        {
            builder.ToTable("local_government_settlements");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x => x.CodeNumber).HasMaxLength(9).IsRequired();
            builder.HasOne(x => x.LocalGovernmentAdministrations).WithMany();
        }
    }

}


