using Entities.Client.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Client
{
    public class GetAllClientsOut : BaseOut
    {
        public List<Client> client { get; set; }
    }
}
