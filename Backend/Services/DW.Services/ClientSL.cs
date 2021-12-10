using DataAccess.DW.DataAccess.Interfaces;
using Entities.Client;
using Services.DW.Services.Interfaces.ClientSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DW.Services.ClientSL
{
    public class ClientSL : IClientSL
    {

        public IClientDA clientDA;
        public ClientSL(IClientDA clientDA)
        {
            this.clientDA = clientDA;
        }

        public CreateClientOut CreateClient(CreateClientIn input)
        {
            return clientDA.CreateClient(input);
        }

        public DeleteClientOut DeleteClient(int clientId)
        {
            return clientDA.DeleteClient(clientId);
        }

        public GetAllClientsOut GetAllClients()
        {
            return clientDA.GetAllClients();
        }

        public UpdateClientOut UpdateClient(UpdateClientIn input)
        {
            return clientDA.UpdateClient(input);
        }

        public GetClientFilterOut GetClientFilterEmail(string email)
        {
            return clientDA.GetClientFilterEmail(email);
        }

        public GetClientFilterOut GetClientFilterLastName(string lastname)
        {
            return clientDA.GetClientFilterLastName(lastname);
        }

        public GetClientFilterOut GetClientFilterName(string firstname)
        {
            return clientDA.GetClientFilterName(firstname);
        }
    }
}
