using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.DTO
{
    public class ClientSeparationProductDetailDTO
    {
        public int? Id { get; set; }
        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Separated Quantity")]
        public int SeparatedQuantity { get; set; }
        public decimal? Price { get; set; }
    }
    public class CreateEditClientSeparationProductDetailDTO
    {
        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Separated Quantity")]
        [Range(1, long.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public int SeparatedQuantity { get; set; } = 1;
    }
    public class ClientSeparationProductDTO
    {
        public int Id { get; set; }
        public string? AvailablePromotion { get; set; }
        public decimal? PromotionPercentage { get; set; }
        public int ClientId { get; set; }
        public DateTime SeparatedDate { get; set; }
        public List<ClientSeparationProductDetailDTO>? ClientSeparationProductDetailDTOs { get; set; }
    }
}
