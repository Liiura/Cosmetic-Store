using BlazorAppShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppShared.DTO
{
    public class SeparatePlanDTO
    {
        public int Id { get; set; }
        public string SeparatePlanName { get; set; }
        public decimal SeparateValue { get; set; }
        public decimal SeparatePlanPercentage { get; set; }
    }
}
