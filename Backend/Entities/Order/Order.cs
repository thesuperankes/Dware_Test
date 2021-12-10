using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Order
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Total { get; set; }
    }
}
