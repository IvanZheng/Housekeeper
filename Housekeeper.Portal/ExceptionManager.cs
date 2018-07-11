using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housekeeper.Portal
{
    public class ExceptionManager: IFramework.Infrastructure.ExceptionManager
    {
        protected override string GetExceptionMessage(Exception ex)
        {
#if DEBUG
            return $"Message:{ex.GetBaseException().Message}\r\nStackTrace:{ex.GetBaseException().StackTrace}";
#else
            return ex.GetBaseException().Message;
#endif
        }
    }
}
