using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class CommunityTypesConfiguration : IEntityTypeConfiguration<CommunityType>
    {

        public void Configure(EntityTypeBuilder<CommunityType> builder)
        {
            builder.ToTable("community_types");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
        }
    }
}
