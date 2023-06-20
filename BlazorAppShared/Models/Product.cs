using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SellDepartmentId { get; set; }
        public virtual SellDepartment SellDepartment { get; set; }
        public virtual List<ProductColorDetail>? ProductColorDetails { get; set; }
        public virtual List<ClientProductPurchaseDetail>? ClientProductPurchaseDetails { get; set; }
        public virtual List<ClientSeparationProductDetail>? ClientSeparationProductDetails { get; set; }

    }
}
