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
    public class AddHelpModel
    {
        [Required]
        public int Customer_id { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }

        private readonly IHelpService _helpService;

        private readonly IMapper _mapper;

        public AddHelpModel()
        {
            _helpService = Startup.AutofacContainer.Resolve<IHelpService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public AddHelpModel(IHelpService helpService)
        {
            _helpService = helpService;
        }

        internal void AddHelp()
        {
            var help = _mapper.Map<Help>(this);

            _helpService.AddHelp(help);

        }
    }
}
