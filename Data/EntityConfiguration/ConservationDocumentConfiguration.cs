using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class ValidationStatusConfiguration : IEntityTypeConfiguration<ConservationDocument>
    {
        public void Configure(EntityTypeBuilder<ConservationDocument> builder)
        {
            builder.ToTable("conservation_documents");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ValidationStatus).IsRequired();
        }
    }
}
