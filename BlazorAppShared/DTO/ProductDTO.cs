using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.DTO
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; } = "";
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public string SellDepartmentName { get; set; } = "";
        public int? SellDepartmentId { get; set; }
        public List<ColorDTO> ColorDTOs { get; set; } = new List<ColorDTO>();
    }
    public class CreateUpdateProductDTO
    {
        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? SellDepartmentId { get; set; }
        public List<ColorProductDTO>? Colors { get; set; }
    }
    public class ColorProductDTO
    {
        [Required]
        public int ColorId { get; set; }
    }
}
