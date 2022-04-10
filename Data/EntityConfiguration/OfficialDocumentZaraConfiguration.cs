using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class OfficialDocumentZaraConfiguration : IEntityTypeConfiguration<OfficialDocumentZara>
    {
        public void Configure(EntityTypeBuilder<OfficialDocumentZara> builder)
        {
            builder.ToTable("official_document_zara");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ShortName);
            builder.HasOne(x => x.DocumentTypeZara).WithMany().HasForeignKey(x => x.DocumentTypeZaraId);
            builder.HasOne(x => x.OfficalSpatialNews).WithMany().HasForeignKey(x => x.OfficalSpatialNewsId);
            builder.Property(x => x.OfficialSpatialNewsNumber).IsRequired();
            builder.Property(x => x.OfficialSpatialNewsNumberUrl);
            builder.HasOne(x => x.DocumentStatusZara).WithMany().HasForeignKey(x => x.DocumentStatusZaraId);
            builder.Property(x => x.DocumentEffectiveDate).IsRequired(false);
            builder.Property(x => x.DocumentIneffectiveDate).IsRequired(false);
            builder.Property(x => x.DocumentRemark);
        }
    }
}
