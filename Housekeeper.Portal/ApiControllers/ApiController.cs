using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFramework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Housekeeper.Portal.ApiControllers
{
    [Route("api/[controller]")]
    public class ApiController: Controller
    {
        protected readonly ILogger Logger;
        protected readonly IExceptionManager ExceptionManager;

        public ApiController(ILogger logger, IExceptionManager exceptionManager)
        {
            Logger = logger;
            ExceptionManager = exceptionManager;
        }
    }
}
