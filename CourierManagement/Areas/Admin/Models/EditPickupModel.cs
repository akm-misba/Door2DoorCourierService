using Autofac;
using CourierManagement.Training.BusinessObjects;
using CourierManagement.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Areas.Admin.Models
{
    public class EditPickupModel
    {
        public int? Id { get; set; }
        [Required]
        public int Order_id { get; set; }
        public int Courier_id { get; set; }
        public string DateAndTime { get; set; }

        private readonly IPickupService _pickupService;

        public EditPickupModel()
        {
            _pickupService = Startup.AutofacContainer.Resolve<IPickupService>();
        }

        public void LoadModelData(int id)
        {
            var pickup = _pickupService.GetPickup(id);
            Id = pickup?.Id;
            Order_id = (int)pickup?.Order_id;
            Courier_id = (int)pickup?.Courier_id;
            DateAndTime = pickup?.DateAndTime;
        }

        internal void Update()
        {
            var pickup = new Pickup
            {
                Id = Id.HasValue ? Id.Value : 0,
                Order_id = Order_id,
                Courier_id = Courier_id,
                DateAndTime = DateAndTime

            };
            _pickupService.UpdatePickup(pickup);
        }
    }
}
