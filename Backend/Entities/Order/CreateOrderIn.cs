using Entities.Client.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Order
{
    public class CreateOrderIn : BaseIn
    {
        public Order order { get; set; }
    }
}
