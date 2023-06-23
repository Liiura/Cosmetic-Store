using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<ClientProductPurchase>? ClientProductDetails { get; set; }
        public virtual List<ClientSeparationProduct>? ClientSeparationProductDetails { get; set; }

    }
}
