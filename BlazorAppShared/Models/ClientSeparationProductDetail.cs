using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.Models
{
    public class ClientSeparationProductDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ClientSeparationProductId { get; set; }
        public virtual ClientSeparationProduct ClientSeparationProduct { get; set; }
        public virtual Product Product { get; set; }
        public int SeparatedQuantity { get; set; }
    }
}
