using System;
using System.Threading.Tasks;
using Housekeeper.Domain.Models;
using Housekeeper.Domain.Repositories;
using IFramework.Exceptions;
using IFramework.UnitOfWork;
using Microsoft.Extensions.Logging;
using Dto = Housekeeper.Application.Contracts.Dto;

namespace Housekeeper.Application
{
    public class HouseAppService : ApplicationService
    {
        public HouseAppService(IHousekeeperRepository repository,
                               IAppUnitOfWork unitOfWork,
                               ILogger<HouseAppService> logger)
            : base(repository, unitOfWork, logger) { }

        public async Task<Dto.House> AddHouseAsync(Dto.House houseAdded)
        {
            var house = new House(houseAdded.Name,
                                  houseAdded.Owner,
                                  houseAdded.Address);
            Repository.Add(house);
            await UnitOfWork.CommitAsync();
            return house;
        }
        
    }
}