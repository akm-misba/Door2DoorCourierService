using Autofac;
using CourierManagement.Training.BusinessObjects;
using CourierManagement.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Areas.Admin.Models
{
    public class EditHelpModel
    {
        public int? Id { get; set; }
        public int Customer_id { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }

        private readonly IHelpService _helpService;

        public EditHelpModel()
        {
            _helpService = Startup.AutofacContainer.Resolve<IHelpService>();
        }

        public void LoadModelData(int id)
        {
            var help = _helpService.GetHelp(id);
            Id = help?.Id;
            Customer_id = (int)help?.Customer_id;
            Message = help?.Message;
            Status = help?.Status;
        }

        internal void Update()
        {
            var help = new Help
            {
                Id = Id.HasValue ? Id.Value : 0,
                Customer_id = Customer_id,
                Message = Message,
                Status = Status

            };
            _helpService.UpdateHelp(help);
        }
    }
}
