using Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DW.DataAccess.Interfaces
{
    public interface IOrderDA
    {
        CreateOrderOut CreateOrder(CreateOrderIn input);
        DeleteOrderOut DeleteOrder(int orderId);
        UpdateOrderOut UpdateOrder(UpdateOrderIn input);

        CreateProductOrderOut CreateProductOrder(CreateProductOrderIn input);

        GetAllOrdersOut GetAllOrders();
    }
}
