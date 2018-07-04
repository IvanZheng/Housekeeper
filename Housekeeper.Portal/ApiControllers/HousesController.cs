using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Housekeeper.Application;
using Housekeeper.Domain.Models;
using Housekeeper.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Housekeeper.Portal.ApiControllers
{
    public class HousesController: ApiController
    {
        private readonly HouseAppService _hosueAppService;
        private readonly IHousekeeperRepository _repository;

        public HousesController(ILogger<HousesController> logger,
                                HouseAppService hosueAppService,
                                    IHousekeeperRepository repository) : base(logger)
        {
            _hosueAppService = hosueAppService;
            _repository = repository;
        }

        public Task<House[]> Get()
        {
            return _repository.FindAll<House>()
                              .ToArrayAsync();
        }

        [HttpPost]
        public string Post()
        {
            return "House";
        }
    }
}
