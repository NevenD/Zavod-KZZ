using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class RailroadCategoryConfiguration : IEntityTypeConfiguration<RailroadCategory>
    {
        public void Configure(EntityTypeBuilder<RailroadCategory> builder)
        {
            builder.ToTable("railroad_categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
        }
    }
}
