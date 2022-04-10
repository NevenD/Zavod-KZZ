using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class LocalGovernmentConfiguration : IEntityTypeConfiguration<LocalGovernmentAdministration>
    {
        public void Configure(EntityTypeBuilder<LocalGovernmentAdministration> builder)
        {
            builder.ToTable("local_governments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(max)");
            builder.Property(x => x.CodeNumber).HasMaxLength(9).IsRequired();
            builder.Property(x => x.SurfaceArea).HasMaxLength(9);
            builder.Property(x => x.Population2001).HasMaxLength(9);
            builder.Property(x => x.Population2011).HasMaxLength(9);
            builder.Property(x => x.Population2021).HasMaxLength(9);
            builder.Property(x => x.WebSiteUrl).HasMaxLength(300);
            builder.Property(x => x.IsAdministrativeCity);
            builder.HasOne(x => x.CommunityType).WithMany();
        }
    }
}
