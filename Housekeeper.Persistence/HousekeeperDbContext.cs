using System;
using Housekeeper.Domain.Models;
using IFramework.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseKeeper.Persistence
{
    public class HousekeeperDbContext: MsDbContext 
    {
        public HousekeeperDbContext(DbContextOptions options) : base(options)
        {
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
    }
}
