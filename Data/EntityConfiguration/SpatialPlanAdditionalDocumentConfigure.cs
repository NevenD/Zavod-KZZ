using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class SpatialPlanAdditionalDocumentConfigure : IEntityTypeConfiguration<SpatialPlanAdditionalDocument>
    {

        public void Configure(EntityTypeBuilder<SpatialPlanAdditionalDocument> builder)
        {
            builder.ToTable("spatial_plan_additional_documents");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.UniqueFileName);
            builder.Property(x => x.FileExtension);
            builder.Property(x => x.FileSizeInMb);
            builder.HasOne(sp => sp.SpatialPlanDocument)
                .WithMany(sd => sd.SpatialPlanAdditionalDocuments)
                .HasForeignKey(x =>x.SpatialPlanDocumentId).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
