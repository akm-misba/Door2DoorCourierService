using Autofac;
using CourierManagement.Training.BusinessObjects;
using CourierManagement.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Areas.Admin.Models
{
    public class EditCustomerModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private readonly ICustomerService _customerService;

        public EditCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }

        public void LoadModelData(int id)
        {
            var customer = _customerService.GetCustomer(id);
            Id = customer?.Id;
            Name = customer?.Name;
            Email = customer?.Email;
            Password = customer?.Password;
        }

        internal void Update()
        {
            var customer = new Customer
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                Email = Email,
                Password = Password

            };
            _customerService.UpdateCustomer(customer);
        }
    }
}
