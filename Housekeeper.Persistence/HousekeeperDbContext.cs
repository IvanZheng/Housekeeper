using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Housekeeper.Domain.Models;
using IFramework.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseKeeper.Persistence
{
    public class HousekeeperDbContext: MsDbContext 
    {
        public static ConcurrentDictionary<int, int> DbContexts = new ConcurrentDictionary<int, int>();
        public static int Count = 0;
        public HousekeeperDbContext(DbContextOptions options) : base(options)
        {
            DbContexts.TryAdd(GetHashCode(), Count ++);
            ChangeTracker.AutoDetectChangesEnabled = false;
            Database.EnsureCreated();
        }

        public DbSet<House> Houses { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<House>()
                        .HasMany(h => h.Rooms)
                        .WithOne();

            modelBuilder.Entity<Item>()
                        .Ignore(i => i.Medias);

            modelBuilder.Owned<Address>();
            modelBuilder.Owned<HouseOwner>();

        }

        public override int SaveChanges()
        {
            UpdateEntitiesModification();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateEntitiesModification();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateEntitiesModification();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        private void UpdateEntitiesModification()
        {
            foreach (var e in ChangeTracker.Entries())
            {
                if (e.Entity is IUpdatable updatable)
                {
                    if (e.State == EntityState.Modified)
                    {
                        updatable.UpdateModification();
                    }
                    else if (e.State == EntityState.Added)
                    {
                        updatable.UpdateCreation();
                    }
                }
            }
        }
    }
}
