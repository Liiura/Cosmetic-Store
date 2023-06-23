using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.Models
{
    public class SeparatePlan
    {
        public int Id { get; set; }
        public string SeparatePlanName { get; set; }
        public decimal SeparateValue { get; set; }
        public decimal SeparatePlanPercentage { get; set; }
        public virtual List<ClientProductPurchase> PurchaseOrders { get; set; }
    }
}
