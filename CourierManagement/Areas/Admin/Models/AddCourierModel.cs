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
    public class AddCourierModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        private readonly ICourierService _courierService;

        private readonly IMapper _mapper;

        public AddCourierModel()
        {
            _courierService = Startup.AutofacContainer.Resolve<ICourierService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public AddCourierModel(ICourierService courierService)
        {
            _courierService = courierService;
        }

        internal void AddCourier()
        {
            var courier = _mapper.Map<Courier>(this);

            _courierService.AddCourier(courier);

        }
    }
}
