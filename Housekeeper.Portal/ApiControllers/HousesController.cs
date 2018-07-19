using System.Threading.Tasks;
using Housekeeper.Application;
using Housekeeper.Domain.Models;
using Housekeeper.Domain.Repositories;
using HouseKeeper.Persistence;
using IFramework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Housekeeper.Portal.ApiControllers
{
    public class HousesController : ApiController
    {
        private readonly HouseAppService _hosueAppService;
        private readonly IHousekeeperRepository _repository;
        private readonly HousekeeperDbContext _dbContext;

        public HousesController(ILogger<HousesController> logger,
                                HouseAppService hosueAppService,
                                IHousekeeperRepository repository,
                                IConcurrencyProcessor concurrencyProcessor,
                                HousekeeperDbContext dbContext) : base(logger, concurrencyProcessor)
        {
            _hosueAppService = hosueAppService;
            _repository = repository;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<House[]> GetAsync()
        {
            var houses = await ProcessAsync(() => _repository.FindAll<House>().ToArrayAsync());
            await Task.Delay(int.MaxValue);
            return houses;
        }

        [HttpPost]
        public Task<string> PostAsync([FromBody]Application.Contracts.Dto.House houseAdded)
        {
            return ProcessAsync(async () =>
            {
                var house = await _hosueAppService.AddHouseAsync(houseAdded)
                                                  .ConfigureAwait(false);
                return house.Id;
            });
        }
    }
}