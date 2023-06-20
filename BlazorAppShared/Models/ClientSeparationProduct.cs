using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.Models
{
    public class ClientSeparationProduct
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? PromotionId { get; set; }
        public DateTime CreatedDate{ get; set; }
        public virtual Client Client { get; set; }
        public virtual Promotion? Promotion { get; set; }
        public virtual List<ClientSeparationProductDetail>? ClientSeparationProductDetails { get; set; }

    }
}
