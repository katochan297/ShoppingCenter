using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Enum
{
    public class DataStatus
    {
        public static readonly short Deleted = 0;
        public static readonly short Available = 1;
        public static readonly short NotAvailable = 2;
        public static readonly short Complete = 3;
    }
}
