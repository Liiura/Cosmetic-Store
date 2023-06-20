using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PromotionName { get; set; }
        public decimal PromotionPercentage { get; set; }
        public decimal MaximalAmount { get; set; }
        public decimal MinimalAmount { get; set; }
        public virtual List<ClientSeparationProduct>? ClientSeparationProducts { get; set; }
    }
}
