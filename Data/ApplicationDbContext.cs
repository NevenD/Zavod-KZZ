using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.Models.ManyToMany;
using ZAVOD_KZZ.Data.EntityConfiguration;
namespace ZAVOD_KZZ.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LocalGovernmentAdministration> LocalGovernmentAdministration { get; set; }
        public DbSet<CommunityType>CommunityTypes { get; set; }
        public DbSet<LocalGovernmentSettlement> LocalGovernmentSettlements { get; set; }
        public DbSet<SettlementLocalGovernment> SettlementLocalGovernments { get; set; }
        public DbSet<SpatialPlanner> SpatialPlanners { get; set; }
        public DbSet<OfficalSpatialNews> OfficalSpatialNews { get; set; }
        public DbSet<SpatialProjection> SpatialProjections { get; set; }
        public DbSet<SpatialMeasure> SpatialMeasures { get; set; }
        public DbSet<SpatialPlanDelivery> SpatialPlanDelivery { get; set; }
        public DbSet<ConservationDocument> ConservationDocuments { get; set; }
        public DbSet<SpatialPlanLevel> SpatialPlanLevels { get; set; }
        public DbSet<SpuoPuoDocument> SpuoPuoDocuments { get; set; }
        public DbSet<SpatialPlanStatus> SpatialPlanStatus { get; set; }
        public DbSet<SpatialPlanRevision> SpatialPlanRevisions { get; set; }
        public DbSet<SpatialPlanDocument> SpatialPlanDocuments { get; set; }
        public DbSet<SpatialPlanAdditionalDocument> SpatialPlanAdditionalDocuments { get; set; }
        public DbSet<RoadCategory> RoadCategories { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DbSet<Railroad> Railroad { get; set; }
        public DbSet<RailroadCategory> RailroadCategory { get; set; }
        public DbSet<RoadLocalGovernment> RoadsLocalGovernment { get; set; }
        public DbSet<RailroadLocalGovernment> RailroadLocalGovernment { get; set; }
        public DbSet<Regulation> Regulations { get; set; }
        public DbSet<NaturalChangePopulation> NaturalChangePopulation { get; set; }
        public DbSet<OfficialDocumentZara> OfficialDocumentZara { get; set; }
        public DbSet<DocumentTypeZara> DocumentTypeZara { get; set; }
        public DbSet<DocumentStatusZara> DocumentStatusZara { get; set; }
        public DbSet<RoadGeometry> RoadGeometry { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateAdded = DateTime.Now.ToLocalTime();
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateModified = DateTime.Now.ToLocalTime();
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
