using Housekeeper.Domain.Repositories;
using HouseKeeper.Persistence;
using IFramework.DependencyInjection;
using IFramework.Repositories;
using IFramework.UnitOfWork;

namespace Housekeeper.Persistence.Repositories
{
    public class HousekeeperRepository : DomainRepository, IHousekeeperRepository
    {
        public HousekeeperRepository(HousekeeperDbContext context,
                                     IAppUnitOfWork unitOfWork,
                                     IObjectProvider objectProvider)
            : base(context, unitOfWork, objectProvider) { }
    }
}