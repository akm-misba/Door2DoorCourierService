using Autofac;
using CourierManagement.Training.BusinessObjects;
using CourierManagement.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Areas.Admin.Models
{
    public class EditTrackModel
    {
        public int? Id { get; set; }
        public int Customer_id { get; set; }
        public int Order_id { get; set; }
        public string Status { get; set; }

        private readonly ITrackService _trackService;

        public EditTrackModel()
        {
            _trackService = Startup.AutofacContainer.Resolve<ITrackService>();
        }

        public void LoadModelData(int id)
        {
            var track = _trackService.GetTrack(id);
            Id = track?.Id;
            Customer_id = (int)track?.Customer_id;
            Order_id = (int)track?.Order_id;
            Status = track?.Status;
        }

        internal void Update()
        {
            var track = new Track
            {
                Id = Id.HasValue ? Id.Value : 0,
                Customer_id = Customer_id,
                Order_id = Order_id,
                Status = Status

            };
            _trackService.UpdateTrack(track);
        }
    }
}
