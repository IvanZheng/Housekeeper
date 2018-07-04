using System;
using System.Collections.Generic;
using System.Text;
using HouseKeeper.Persistence;
using IFramework.EntityFrameworkCore.Repositories;
using IFramework.UnitOfWork;

namespace Housekeeper.Persistence.Repositories
{
    public class RepositoryBase<TEntity> : Repository<TEntity> where TEntity : class
    {
        public RepositoryBase(HousekeeperDbContext dbContext, IAppUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
