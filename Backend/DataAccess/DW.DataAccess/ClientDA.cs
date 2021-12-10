using Dapper;
using DataAccess.DW.DataAccess.Interfaces;
using Entities.Client;
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
    public class ClientDA : IClientDA
    {
        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public CreateClientOut CreateClient(CreateClientIn input)
        {
            CreateClientOut response = new CreateClientOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error,
                Message = ""
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();

                    var sql = @"INSERT INTO tbl_Client ([FirstName],[LastName],[Age],[Identification],[Email],[CreationDate]) VALUES (@FirstName, @LastName, @Age, @Identification,@Email, GETDATE());
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                    var clientId = connection.ExecuteScalar<int>(sql, input.client);

                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;
                    response.clientId = clientId;

                }

                return response;
            }
            catch (SqlException ex)
            {
                response.Message = "Ocurrio un problema al crear el cliente";
                return response;
            }

        }

        public UpdateClientOut UpdateClient(UpdateClientIn input)
        {
            UpdateClientOut response = new UpdateClientOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = @"UPDATE tbl_Client SET [FirstName] = @FirstName,[LastName] = @LastName,[Age] = @Age,[Identification] = @Identification,[Email] = @Email WHERE ClientId = @ClientId";

                    connection.Execute(sql, input.client);
                }

                return response;
            }
            catch (SqlException ex)
            {
                response.Message = "Ocurrio un problema al actualizar el cliente";
                return response;
            }

        }

        public DeleteClientOut DeleteClient(int clientId)
        {

            DeleteClientOut response = new DeleteClientOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = "DELETE FROM tbl_Client WHERE ClientId = @ClientId";

                    connection.Execute(sql, new { ClientId = clientId });

                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;
                }

                return response;
            }
            catch (SqlException ex)
            {

                response.Message = "Ocurrio un problema al eliminar el cliente";
                return response;
            }

        }

        public GetAllClientsOut GetAllClients()
        {
            GetAllClientsOut response = new GetAllClientsOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();


                    var data = connection.Query<Client>("SELECT [ClientId] ,[FirstName] ,[LastName] ,[Age] ,[Identification] ,[Email] ,[CreationDate] FROM [tbl_Client] ORDER BY CreationDate DESC");

                    var clientList = new List<Client>();

                    foreach (var i in data)
                    {
                        var client = new Client()
                        {
                            ClientId = i.ClientId,
                            FirstName = i.FirstName,
                            LastName = i.LastName,
                            Age = i.Age,
                            Identification = i.Identification,
                            Email = i.Email,
                            CreationDate = i.CreationDate

                        };

                        clientList.Add(client);
                    }

                    response.client = clientList;

                    if (response.client.Count > 0)
                        response.ResponseCode = Entities.Client.General.ResponseCode.Success;

                }

                return response;
            }
            catch (SqlException ex)
            {
                response.Message = "Ocurrio un problema al obtener los clientes";
                return response;
            }

        }

        public GetClientFilterOut GetClientFilterEmail(string email)
        {
            GetClientFilterOut response = new GetClientFilterOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query<Client>($"SELECT ClientId,FirstName,LastName,Age,Identification,Email,CreationDate FROM tbl_Client WHERE Email LIKE'%{ email }%'");

                var clientList = new List<Client>();

                foreach (var i in data)
                {
                    var client = new Client()
                    {
                        ClientId = i.ClientId,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Age = i.Age,
                        Identification = i.Identification,
                        Email = i.Email,
                        CreationDate = i.CreationDate

                    };

                    clientList.Add(client);
                }

                response.client = clientList;

                if (response.client.Count > 0)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public GetClientFilterOut GetClientFilterLastName(string lastname)
        {
            GetClientFilterOut response = new GetClientFilterOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query<Client>("SELECT ClientId,FirstName,LastName,Age,Identification,Email,CreationDate FROM tbl_Client WHERE LastName LIKE'%" + lastname + "%'");

                var clientList = new List<Client>();

                foreach (var i in data)
                {
                    var client = new Client()
                    {
                        ClientId = i.ClientId,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Age = i.Age,
                        Identification = i.Identification,
                        Email = i.Email,
                        CreationDate = i.CreationDate

                    };

                    clientList.Add(client);
                }

                response.client = clientList;

                if (response.client.Count > 0)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }

        public GetClientFilterOut GetClientFilterName(string firstname)
        {
            GetClientFilterOut response = new GetClientFilterOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error
            };

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();


                var data = connection.Query<Client>("SELECT ClientId,FirstName,LastName,Age,Identification,Email,CreationDate FROM tbl_Client WHERE FirstName LIKE'%" + firstname + "%'");

                var clientList = new List<Client>();

                foreach (var i in data)
                {
                    var client = new Client()
                    {
                        ClientId = i.ClientId,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Age = i.Age,
                        Identification = i.Identification,
                        Email = i.Email,
                        CreationDate = i.CreationDate

                    };

                    clientList.Add(client);
                }

                response.client = clientList;

                if (response.client.Count > 0)
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

            }

            return response;
        }


    }
}
