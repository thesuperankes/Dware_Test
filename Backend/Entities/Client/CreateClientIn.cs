using Entities.Client.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Client
{
    public class CreateClientIn : BaseIn
    {
        public Client client { get; set; }
    }
}
