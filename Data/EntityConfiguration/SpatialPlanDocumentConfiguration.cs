using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class SpatialPlanDocumentConfiguration : IEntityTypeConfiguration<SpatialPlanDocument>
    {
        public void Configure(EntityTypeBuilder<SpatialPlanDocument> builder)
        {
            builder.ToTable("spatial_plan_documents");
            builder.HasKey(x => x.Id);
            builder.HasOne(loc => loc.LocalGovernmentAdministration)
                .WithMany();
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(500);
            builder.Property(x => x.RevisionName).HasMaxLength(500);
            builder.Property(x => x.IspuName).HasMaxLength(50);
            builder.Property(x => x.OfficialSpatialNewsNumber).IsRequired();
            builder.Property(x => x.OfficialSpatialNewsNumberUrl).HasColumnType("nvarchar(max)");
            builder.Property(x => x.SpatialPlanPublicationDate).IsRequired(false);
            builder.Property(x => x.SpatialPlanEffectiveDate).IsRequired(false);
            builder.Property(x => x.OfficialSpatialNewsRemark).HasColumnType("nvarchar(max)");
            builder.Property(x => x.SpatialPlanAnnouncementDevelopDate).IsRequired(false);
            builder.Property(x => x.SpatialPlanApprovalRemark).HasColumnType("nvarchar(max)");
            builder.Property(x => x.SpatialPlanDocumentationRemark).HasColumnType("nvarchar(max)");
            builder.Property(x => x.DateArchived).IsRequired(false);
        }
    }
}
