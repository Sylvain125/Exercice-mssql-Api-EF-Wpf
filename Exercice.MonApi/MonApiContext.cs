using Exercice.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exercice.MonApi
{
    public class MonApiContext : DbContext
    {
        public MonApiContext(DbContextOptions<MonApiContext> options) : base(options)
        {

        }

        //private string ConnectionString { get; }
        //public MonApiContext(string connectionString)
        //{
        //    ConnectionString = connectionString;
        //}

        // Pour set une autre db ca se passs ici 

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //   // optionsBuilder.UseSqlServer(ConnectionString);
        //}

        public DbSet<UserInfoEntity> UserInfosEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // var userBuilder = modelBuilder.Entity<User>();

            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("SalesLT");

            EntityTypeBuilder<UserInfoEntity> entityTypeBuilder = modelBuilder.Entity<UserInfoEntity>();

        }

        public override DbSet<UserInfoEntity> Set<UserInfoEntity>()
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return base.Set<UserInfoEntity>();
        }

    }
}
