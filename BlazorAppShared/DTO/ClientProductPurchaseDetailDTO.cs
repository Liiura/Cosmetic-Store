using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.DTO
{
    public class ClientProductPurchaseDetailDTO
    {
        public int? Id { get; set; }
        public int QuantityPurchase { get; set; }
        public decimal? CurrentProductPrice { get; set; }
        public int ProductId { get; set; }
    }
    public class CreateEditClientProductPurchaseDetailDTO
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int QuantityPurchase { get; set; } = 1;
        [Required]
        public decimal CurrentProductPrice { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
    public class ClientProductPurchaseDTO
    {
        public int? Id { get; set;}
        public int ClientId { get; set; }
        public DateTime PurchaseDate { get; set;}
        public decimal? SeparatePlanPercentage { get; set; }
        public List<ClientProductPurchaseDetailDTO>? PurchaseDetails { get; set;}
    }
}
