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
    public class AddCustomerModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      

        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;

        public AddCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public AddCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        internal void AddCustomer()
        {
            var customer = _mapper.Map<Customer>(this);

            _customerService.AddCustomer(customer);

        }
    }
}
