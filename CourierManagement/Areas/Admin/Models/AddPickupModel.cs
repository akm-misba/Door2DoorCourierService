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
    public class AddPickupModel
    {
        [Required]
        public int Order_id { get; set; }
        public int Courier_id { get; set; }
        public string DateAndTime { get; set; }

        private readonly IPickupService _pickupService;

        private readonly IMapper _mapper;

        public AddPickupModel()
        {
            _pickupService = Startup.AutofacContainer.Resolve<IPickupService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public AddPickupModel(IPickupService pickupService)
        {
            _pickupService = pickupService;
        }

        internal void AddPickup()
        {
            var pickup = _mapper.Map<Pickup>(this);

            _pickupService.AddPickup(pickup);

        }
    }
}
