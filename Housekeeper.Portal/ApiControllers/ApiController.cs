using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Housekeeper.Portal.ApiControllers
{
    [Route("api/[controller]")]
    public class ApiController: Controller
    {
        protected readonly ILogger Logger;
        public ApiController(ILogger logger)
        {
            Logger = logger;
        }
    }
}
