using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFramework.AspNet;
using IFramework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Housekeeper.Portal.ApiControllers
{
    [ServiceFilter(typeof(IApiResultWrapAttribute))]
    [Route("api/[controller]")]
    public class ApiController: ApiControllerBase
    {
        protected readonly ILogger Logger;

        public ApiController(ILogger logger, IConcurrencyProcessor concurrencyProcessor)
            : base(concurrencyProcessor)
        {
            Logger = logger;
        }
    }
}
