using System;
using IFramework.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseKeeper.Persistence
{
    public class HousekeeperDbContext: MsDbContext 
    {
        public HousekeeperDbContext(DbContextOptions options) : base(options) { }
    }
}
