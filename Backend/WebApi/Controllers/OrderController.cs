using DataAccess.DW.DataAccess;
using Entities.Order;
using Services.DW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        OrderSL client = new OrderSL(new OrderDA());

        [HttpPost, Route("api/order")]
        public IHttpActionResult CreateOrder(CreateOrderIn input)
        {
            var response = client.CreateOrder(input);
            return Ok(response);
        }

        [HttpDelete, Route("api/order/{orderId}")]
        public IHttpActionResult DeleteOrder(int orderId)
        {
            var response = client.DeleteOrder(orderId);
            return Ok(response);
        }

        [HttpPut, Route("api/order")]
        public IHttpActionResult UpdateOrderIn(UpdateOrderIn input)
        {
            var response = client.UpdateOrder(input);
            return Ok(response);
        }

        [HttpPost, Route("api/order/product")]
        public IHttpActionResult CreateProductOrder(CreateProductOrderIn input)
        {
            var response = client.CreateProductOrder(input);
            return Ok(response);
        }

        [HttpGet, Route("api/order")]
        public IHttpActionResult GetAllOrders()
        {
            var response = client.GetAllOrders();
            return Ok(response);
        }
    }
}
