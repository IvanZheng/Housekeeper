using Microsoft.Extensions.Logging;

namespace Housekeeper.Portal.ApiControllers
{
    public class AccountsController : ApiController
    {
        public AccountsController(ILogger<AccountsController> logger) : base(logger) { }
    }
}