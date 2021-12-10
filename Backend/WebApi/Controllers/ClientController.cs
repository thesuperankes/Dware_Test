using DataAccess.DW.DataAccess;
using Entities.Client;
using Services.DW.Services.ClientSL;
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
    public class ClientController : ApiController
    {
        ClientSL client = new ClientSL(new ClientDA());

        [Route("api/client")]
        [HttpPost]
        public IHttpActionResult CreateClient(CreateClientIn input)
        {
            var response = client.CreateClient(input);

            return Ok(response);
        }

        [Route("api/client/{clientId}")]
        [HttpDelete]
        public IHttpActionResult DeleteClient(int clientId)
        {
            var response = client.DeleteClient(clientId);

            return Ok(response);
        }

        [Route("api/client")]
        [HttpPut]
        public IHttpActionResult UpdateClient(UpdateClientIn input)
        {
            var response = client.UpdateClient(input);

            return Ok(response);
        }

        [HttpGet, Route("api/client")]
        public GetAllClientsOut GetAllClients()
        {
            var response = client.GetAllClients();

            return response;
        }

        [HttpGet, Route("api/client/firstname/{firstname}")]
        public IHttpActionResult GetClientFilterName(string firstname)
        {
            var response = client.GetClientFilterName(firstname);

            return Ok(response);
        }
        [HttpGet, Route("api/client/lastname/{lastname}")]
        public IHttpActionResult GetClientFilterLastName(string lastname)
        {
            var response = client.GetClientFilterLastName(lastname);

            return Ok(response);
        }

        [HttpGet, Route("api/client/email/{email}")]
        public IHttpActionResult GetClientFilterEmail(string email)
        {
            var response = client.GetClientFilterEmail(email);

            return Ok(response);
        }
    }
}
