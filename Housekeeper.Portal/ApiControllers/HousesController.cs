using System.Threading.Tasks;
using Housekeeper.Application;
using Housekeeper.Domain.Models;
using Housekeeper.Domain.Repositories;
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

        public HousesController(ILogger<HousesController> logger,
                                HouseAppService hosueAppService,
                                IHousekeeperRepository repository,
                                IExceptionManager exceptionManager) : base(logger, exceptionManager)
        {
            _hosueAppService = hosueAppService;
            _repository = repository;
        }

        [HttpGet]
        public Task<ApiResult<House[]>> GetAsync()
        {
            return ExceptionManager.ProcessAsync(() => _repository.FindAll<House>()
                                                                  .ToArrayAsync());
        }

        [HttpPost]
        public Task<ApiResult<string>> PostAsync([FromBody]Application.Contracts.Dto.House houseAdded)
        {
            return ExceptionManager.ProcessAsync(async () =>
            {
                var house = await _hosueAppService.AddHouseAsync(houseAdded)
                                                  .ConfigureAwait(false);
                return house.Id;
            });
        }
    }
}