using Entities.Client.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class GetProductFilterOut : BaseOut
    {
        public List<Product> product { get; set; }
    }
}
