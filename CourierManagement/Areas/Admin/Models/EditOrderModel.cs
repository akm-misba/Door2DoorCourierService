using Autofac;
using CourierManagement.Training.BusinessObjects;
using CourierManagement.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Areas.Admin.Models
{
    public class EditOrderModel
    {
        public int? Id { get; set; }
        public int Customer_id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Source_to_office { get; set; }
        public string Office_to_destination { get; set; }
        public string Amount { get; set; }
        public string Transaction_id { get; set; }
        public string Payment { get; set; }

        private readonly IOrderService _orderService;

        public EditOrderModel()
        {
            _orderService = Startup.AutofacContainer.Resolve<IOrderService>();
        }

        public void LoadModelData(int id)
        {
            var order = _orderService.GetOrder(id);
            Id = order?.Id;
            Customer_id = (int)order?.Customer_id;
            From = order?.From;
            To = order?.To;
            Source_to_office = order?.Source_to_office;
            Office_to_destination = order?.Office_to_destination;
            Amount = order?.Amount;
            Transaction_id = order?.Transaction_id;
            Payment = order?.Payment;
        }

        internal void Update()
        {
            var order = new Order
            {
                Id = Id.HasValue ? Id.Value : 0,
                Customer_id = Customer_id,
                From = From,
                To = To,
                Source_to_office = Source_to_office,
                Office_to_destination = Office_to_destination,
                Amount = Amount,
                Transaction_id = Transaction_id,
                Payment = Payment

            };
            _orderService.UpdateOrder(order);
        }
    }
}
