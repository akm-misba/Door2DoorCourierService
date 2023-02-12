using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Areas.Admin.Models
{
    public class PriceCalculationModel
    {
        public double Quantity { get; set; }
        public double Distance { get; set; }
        public double Cost { get; set; }
        public double Total { get; set; }
    }
}
