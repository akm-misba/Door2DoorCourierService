using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.BusinessObjects
{
    public class Help
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
