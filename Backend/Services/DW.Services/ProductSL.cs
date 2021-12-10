using DataAccess.DW.DataAccess.Interfaces;
using Entities.Product;
using Services.DW.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DW.Services
{
    public class ProductSL : IProductSL
    {
        public IProductDA productDA;
        public ProductSL(IProductDA productDA)
        {
            this.productDA = productDA;
        }
        public CreateProductOut CreateProduct(CreateProductIn input)
        {
            return productDA.CreateProduct(input);
        }

        public DeleteProductOut DeleteProduct(int productId)
        {
            return productDA.DeleteProduct(productId);
        }

        public GetAllProductsOut GetAllProduct()
        {
            return productDA.GetAllProduct();
        }

        public GetProductFilterOut GetProductByName(string name)
        {
            return productDA.GetProductByName(name);
        }

        public UpdateProductOut UpdateProduct(UpdateProductIn input)
        {
            return productDA.UpdateProduct(input);
        }
    }
}
