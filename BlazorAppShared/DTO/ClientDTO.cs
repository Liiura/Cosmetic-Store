using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.DTO
{
    public class ClientDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
    public class CreateEditClientDTO {
        [Required]
        public string Name { get; set; }
    }
}
