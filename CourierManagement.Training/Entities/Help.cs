using CourierManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.Entities
{
    public class Help : IEntity<int>
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
