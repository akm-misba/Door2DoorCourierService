using Autofac;
using AutoMapper;
using CourierManagement.Training.BusinessObjects;
using CourierManagement.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Areas.Admin.Models
{
    public class AddTrackModel
    {
        public int Customer_id { get; set; }
        public int Order_id { get; set; }
        public string Status { get; set; }

        private readonly ITrackService _trackService;

        private readonly IMapper _mapper;

        public AddTrackModel()
        {
            _trackService = Startup.AutofacContainer.Resolve<ITrackService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }
        public AddTrackModel(ITrackService trackService)
        {
            _trackService = trackService;
        }

        internal void AddTrack()
        {
            var track = _mapper.Map<Track>(this);

            _trackService.AddTrack(track);

        }
    }
}
