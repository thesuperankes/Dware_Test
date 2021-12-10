using Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DW.Services.Interfaces
{
    public interface IProductSL
    {
        CreateProductOut CreateProduct(CreateProductIn input);
        UpdateProductOut UpdateProduct(UpdateProductIn input);
        DeleteProductOut DeleteProduct(int productId);
        GetAllProductsOut GetAllProduct();
        GetProductFilterOut GetProductByName(string name);
    }
}
