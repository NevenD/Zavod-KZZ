using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class SpatialPlanRevisionConfiguration : IEntityTypeConfiguration<SpatialPlanRevision>
    {
        public void Configure(EntityTypeBuilder<SpatialPlanRevision> builder)
        {
            builder.ToTable("spatial_plan_revisions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RevisionStatus).IsRequired();
        }
    }
}
