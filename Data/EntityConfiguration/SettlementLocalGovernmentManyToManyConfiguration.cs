using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.Models.ManyToMany;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class SettlementLocalGovernmentManyToManyConfiguration : IEntityTypeConfiguration<SettlementLocalGovernment>
    {
        public void Configure(EntityTypeBuilder<SettlementLocalGovernment> builder)
        {
            builder.ToTable("settlement_localgovernment");
            builder.HasKey(x => new {x.Id, x.SettlementID, x.LocalGovernmentAdministrationID });
            builder.HasOne(set => set.Settlement)
                .WithMany(setl => setl.SettlementLocalGovernments)
                .HasForeignKey(set => set.SettlementID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(loc => loc.LocalGovernment)
                .WithMany(setl => setl.SettlementLocalGovernments)
                .HasForeignKey(setl => setl.LocalGovernmentAdministrationID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
