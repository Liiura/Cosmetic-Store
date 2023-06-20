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
    }
    public class CreateEditClientSeparationProductDetailDTO
    {
        [Required]
        [Display(Name = "Product")]
        public int? ProductId { get; set; }
        [Required]
        [Display(Name = "Separated Quantity")]
        public int? SeparatedQuantity { get; set; }
    }
    public class ClientSeparationProductDTO
    {
        public int Id { get; set; }
        public string? AvailablePromotion { get; set; }
        public int ClientId { get; set; }
        public DateTime SeparatedDate { get; set; }
        public List<ClientSeparationProductDetailDTO>? ClientSeparationProductDetailDTOs { get; set; }
    }
}
