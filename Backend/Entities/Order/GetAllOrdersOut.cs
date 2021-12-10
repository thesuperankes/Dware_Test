using Entities.Client.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Order
{
    public class GetAllOrdersOut : BaseOut
    {
        public List<Order> order { get; set; }
    }
}
