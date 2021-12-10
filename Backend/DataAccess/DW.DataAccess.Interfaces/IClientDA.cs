using Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DW.DataAccess.Interfaces
{
    public interface IClientDA
    {
        CreateClientOut CreateClient(CreateClientIn input);
        DeleteClientOut DeleteClient(int clientId);
        UpdateClientOut UpdateClient(UpdateClientIn input);
        GetAllClientsOut GetAllClients();

        GetClientFilterOut GetClientFilterName(string firstname);
        GetClientFilterOut GetClientFilterLastName(string lastname);
        GetClientFilterOut GetClientFilterEmail(string email);
    }
}
