using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.BusinessObjects
{
    public class Pickup
    {
        public int Id { get; set; }
        public int Order_id { get; set; }
        public int Courier_id { get; set; }
        public string DateAndTime { get; set; }
    }
}
