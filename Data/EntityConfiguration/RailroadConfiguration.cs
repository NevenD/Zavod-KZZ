using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class RailroadConfiguration : IEntityTypeConfiguration<Railroad>
    {
        public void Configure(EntityTypeBuilder<Railroad> builder)
        {
            builder.ToTable("railroads");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).HasMaxLength(300).IsRequired();
            builder.HasOne(x => x.RailroadCategory).WithMany().HasForeignKey(x => x.RailroadCategoryID);
            builder.Property(x => x.FullName).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.ShortName).HasColumnType("nvarchar(max)");
            builder.Property(x => x.ConstructionLength).HasMaxLength(9).IsRequired();
            builder.Property(x => x.Lenght).HasMaxLength(9).IsRequired();
            builder.Property(x => x.TrainStationNumber).HasMaxLength(9).IsRequired();
            builder.Property(x => x.TrainPositionNumber).HasMaxLength(9).IsRequired();
            builder.Property(x => x.ReconstructionDateStart);
            builder.Property(x => x.ReconstructionDateEnd);
            builder.Property(x => x.ReconstructionLenght).HasMaxLength(9);
            builder.Property(x => x.Remark).HasColumnType("nvarchar(max)");
        }
    }
}
