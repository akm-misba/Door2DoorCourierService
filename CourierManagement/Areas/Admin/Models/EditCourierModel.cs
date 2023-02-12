using Autofac;
using CourierManagement.Training.BusinessObjects;
using CourierManagement.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Areas.Admin.Models
{
    public class EditCourierModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private readonly ICourierService _courierService;

        public EditCourierModel()
        {
            _courierService = Startup.AutofacContainer.Resolve<ICourierService>();
        }

        public void LoadModelData(int id)
        {
            var courier = _courierService.GetCourier(id);
            Id = courier?.Id;
            Name = courier?.Name;
            Email = courier?.Email;
            Password = courier?.Password;
        }

        internal void Update()
        {
            var courier = new Courier
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                Email = Email,
                Password = Password

            };
            _courierService.UpdateCourier(courier);
        }
    }
}
