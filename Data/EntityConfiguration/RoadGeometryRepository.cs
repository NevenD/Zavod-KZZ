using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.EntityConfiguration
{
    public class RoadGeometryRepository : IEntityTypeConfiguration<RoadGeometry>
    {
        public void Configure(EntityTypeBuilder<RoadGeometry> builder)
        {
            builder.ToTable("sorted_roads_geometry");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Road).WithMany(y => y.Geometries);
            builder.Property(x => x.CoordinatesUnprojected).HasColumnType("nvarchar(max)");
            builder.Property(x => x.GeoJSON).HasColumnType("nvarchar(max)");
            builder.Property(x => x.WKT).HasColumnType("nvarchar(max)");
        }
    }
}
