using Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DW.DataAccess.Interfaces
{
    public interface IProductDA
    {
        CreateProductOut CreateProduct(CreateProductIn input);
        DeleteProductOut DeleteProduct(int productId);
        UpdateProductOut UpdateProduct(UpdateProductIn input);
        GetAllProductsOut GetAllProduct();
        GetProductFilterOut GetProductByName(string name);
    }
}
