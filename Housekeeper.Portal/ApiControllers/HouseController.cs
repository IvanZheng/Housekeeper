using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Housekeeper.Application;
using Housekeeper.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Housekeeper.Portal.ApiControllers
{
    public class HouseController: ApiController
    {
        private readonly HouseAppService _hosueAppService;

        public HouseController(ILogger<HouseController> logger,
                               HouseAppService hosueAppService) : base(logger)
        {
            _hosueAppService = hosueAppService;
        }
    }
}
