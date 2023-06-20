using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.Models
{
    public class ClientProductPurchaseDetail
    {
        public int Id { get; set; }
        public int QuantityPurchase { get; set; }
        public decimal? CurrentProductPrice { get; set; }
        public int ProductId { get; set; }
        public int ClientProductPurchaseId { get; set; }
        public virtual ClientProductPurchase ClientProductPurchase { get; set; }
        public virtual Product Product { get; set; }
    }
}
