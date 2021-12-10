using Entities.Client.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Client
{
    public class Client : BaseIn
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
