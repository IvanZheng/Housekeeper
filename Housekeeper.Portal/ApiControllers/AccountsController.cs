using IFramework.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Housekeeper.Portal.ApiControllers
{
    public class AccountsController : ApiController
    {
        public AccountsController(ILogger logger, IExceptionManager exceptionManager) : base(logger, exceptionManager) { }
    }
}