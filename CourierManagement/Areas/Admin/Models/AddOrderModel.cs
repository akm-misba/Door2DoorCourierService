using Autofac;
using AutoMapper;
using CourierManagement.Training.BusinessObjects;
using CourierManagement.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Areas.Admin.Models
{
    public class AddOrderModel
    {
        [Required]
        public int Customer_id { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        public string Source_to_office { get; set; }
        public string Office_to_destination { get; set; }
        public string Amount { get; set; }
        [Required]
        public string Transaction_id { get; set; }
        public string Payment { get; set; }

        private readonly IOrderService _orderService;

        private readonly IMapper _mapper;

        public AddOrderModel()
        {
            _orderService = Startup.AutofacContainer.Resolve<IOrderService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public AddOrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        internal void AddOrder()
        {
            var order = _mapper.Map<Order>(this);

            _orderService.AddOrder(order);

        }
    }
}
