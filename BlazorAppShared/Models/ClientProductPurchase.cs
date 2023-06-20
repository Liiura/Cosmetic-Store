using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.Models
{
    public class ClientProductPurchase
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<ClientProductPurchaseDetail>? ClientProductPurchaseDetails { get; set; }
    }
}
