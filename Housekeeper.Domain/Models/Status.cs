using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Housekeeper.Domain.Models
{
    public enum Status
    {
        [Description("正常")]
        Normal,
        [Description("已删除")]
        Deleted
    }
}
