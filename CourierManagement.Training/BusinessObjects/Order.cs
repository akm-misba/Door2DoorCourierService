using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.BusinessObjects
{
    public class Order
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Source_to_office { get; set; }
        public string Office_to_destination { get; set; }
        public string Amount { get; set; }
        public string Transaction_id { get; set; }
        public string Payment { get; set; }
    }
}
