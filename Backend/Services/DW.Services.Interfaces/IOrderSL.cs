using Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DW.Services.Interfaces
{
    public interface IOrderSL
    {
        CreateOrderOut CreateOrder(CreateOrderIn input);
        DeleteOrderOut DeleteOrder(int orderId);
        UpdateOrderOut UpdateOrder(UpdateOrderIn input);

        CreateProductOrderOut CreateProductOrder(CreateProductOrderIn input);
        GetAllOrdersOut GetAllOrders();
    }
}
