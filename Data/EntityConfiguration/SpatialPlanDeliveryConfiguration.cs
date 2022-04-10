using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class SpatialPlanDeliveryConfiguration : IEntityTypeConfiguration<SpatialPlanDelivery>
    {
        public void Configure(EntityTypeBuilder<SpatialPlanDelivery> builder)
        {
            builder.ToTable("spatial_plan_delivery");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DeliveryStatus).IsRequired();
        }
    }
}
