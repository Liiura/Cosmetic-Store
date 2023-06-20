using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.DTO
{
    public class PromotionDTO
    {
        public int? Id { get; set; }
        public string PromotionName { get; set; }
        public decimal PromotionPercentage { get; set; }
        public decimal MaximalAmount { get; set; }
        public decimal MinimalAmount { get; set; }
    }
}
