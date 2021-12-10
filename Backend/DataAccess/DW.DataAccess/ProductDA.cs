using Dapper;
using DataAccess.DW.DataAccess.Interfaces;
using Entities.Product;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DW.DataAccess
{
    public class ProductDA : IProductDA
    {
        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public CreateProductOut CreateProduct(CreateProductIn input)
        {
            CreateProductOut response = new CreateProductOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = @"INSERT INTO tbl_Product([Name],Quantity,Price,CreationDate) VALUES(@Name,@Quantity,@Price,GETDATE());
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                    var productId = connection.ExecuteScalar<int>(sql, input.product);

                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;
                    response.productId = productId;

                }

                return response;
            }
            catch (SqlException ex)
            {
                response.Message = "Ocurrio un problema al crear el producto";
                return response;
            }

        }
        public UpdateProductOut UpdateProduct(UpdateProductIn input)
        {
            UpdateProductOut response = new UpdateProductOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = @"UPDATE tbl_Product SET [Name] = @Name,Quantity = @Quantity,Price = @Price WHERE ProductId = @ProductId";

                    connection.ExecuteScalar<int>(sql, input.product);

                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

                }

                return response;
            }
            catch (SqlException ex)
            {
                response.Message = "Ocurrio un problema al actualizar el producto";
                return response;
            }

        }
        public DeleteProductOut DeleteProduct(int productId)
        {
            DeleteProductOut response = new DeleteProductOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = @"DELETE FROM tbl_Product WHERE ProductId = @ProductId";

                    connection.ExecuteScalar<int>(sql, new { ProductId = productId });

                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

                }

                return response;
            }
            catch (SqlException ex)
            {
                response.Message = "Ocurrio un problema al eliminar el producto";
                return response;
            }

        }

        public GetAllProductsOut GetAllProduct()
        {
            GetAllProductsOut response = new GetAllProductsOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();


                    var data = connection.Query<Product>("SELECT [ProductId] ,[Name] ,[Quantity] ,[Price] ,[CreationDate] FROM [tbl_Product] ORDER BY CreationDate DESC");

                    var productList = new List<Product>();
                    foreach (var i in data)
                    {
                        var product = new Product()
                        {
                            ProductId = i.ProductId,
                            Name = i.Name,
                            Quantity = i.Quantity,
                            Price = i.Price,
                            CreationDate = i.CreationDate

                        };

                        productList.Add(product);
                    }

                    response.product = productList;

                    if (response.product.Count > 0)
                        response.ResponseCode = Entities.Client.General.ResponseCode.Success;

                }

                return response;
            }
            catch (SqlException ex)
            {
                response.Message = "Ocurrio un problema al obtener los productos";
                return response;
            }

        }

        public GetProductFilterOut GetProductByName(string name)
        {
            GetProductFilterOut response = new GetProductFilterOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();


                    var data = connection.Query<Product>("SELECT [ProductId] ,[Name] ,[Quantity] ,[Price] ,[CreationDate] FROM [tbl_Product] WHERE Name LIKE '%" + name + "%' ORDER BY CreationDate DESC");

                    var productList = new List<Product>();
                    foreach (var i in data)
                    {
                        var product = new Product()
                        {
                            ProductId = i.ProductId,
                            Name = i.Name,
                            Quantity = i.Quantity,
                            Price = i.Price,
                            CreationDate = i.CreationDate

                        };

                        productList.Add(product);
                    }

                    response.product = productList;

                    if (response.product.Count > 0)
                        response.ResponseCode = Entities.Client.General.ResponseCode.Success;

                }

                return response;
            }
            catch (SqlException ex)
            {
                response.Message = "Ocurrio un problema al obtener los productos";
                return response;
            }

        }

    }
}
