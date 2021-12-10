using Entities.Client.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Order
{
    public class CreateOrderOut : BaseOut
    {
        public int OrderId { get; set; }
    }
}
