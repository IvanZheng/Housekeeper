using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housekeeper.Portal.Filters
{
    public class ApiResultWrapAttribute : IFramework.AspNet.ApiResultWrapAttribute
    {
        public override Exception OnException(Exception ex)
        {
            return base.OnException(ex);
        }
    }
}
