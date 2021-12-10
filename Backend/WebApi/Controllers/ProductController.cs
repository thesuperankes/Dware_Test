using DataAccess.DW.DataAccess;
using Entities.Product;
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
    public class ProductController : ApiController
    {
        ProductSL Product = new ProductSL(new ProductDA());

        [HttpPost, Route("api/product")]
        public IHttpActionResult CreateProduct(CreateProductIn input)
        {
            var response = Product.CreateProduct(input);

            return Ok(response);
        }

        [HttpDelete, Route("api/product/{productId}")]
        public IHttpActionResult DeleteProduct(int productId)
        {
            var response = Product.DeleteProduct(productId);

            return Ok(response);
        }

        [HttpPut, Route("api/product")]
        public IHttpActionResult UpdateProduct(UpdateProductIn input)
        {
            var response = Product.UpdateProduct(input);

            return Ok(response);
        }

        [HttpGet, Route("api/product")]
        public IHttpActionResult GetAllProducts()
        {
            var response = Product.GetAllProduct();

            return Ok(response);
        }

        [HttpGet, Route("api/product/{name}")]
        public IHttpActionResult GetProductByName(string name)
        {
            var response = Product.GetProductByName(name);

            return Ok(response);
        }
    }
}
