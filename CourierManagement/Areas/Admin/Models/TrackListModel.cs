using Autofac;
using CourierManagement.Common.Utilities;
using CourierManagement.Training.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Areas.Admin.Models
{
    public class TrackListModel
    {
        private ITrackService _trackService;
        private IHttpContextAccessor _httpContextAccessor;
        public TrackListModel()
        {
            _trackService = Startup.AutofacContainer.Resolve<ITrackService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public TrackListModel(ITrackService trackService, IHttpContextAccessor httpContextAccessor)
        {
            _trackService = trackService;
            _httpContextAccessor = httpContextAccessor;
        }

        internal object GetTracks(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _trackService.GetTracks(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Customer_id", "Order_id", "Status" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Customer_id.ToString(),
                            record.Order_id.ToString(),
                            record.Status,
                            record.Id.ToString(),

                        }
                        ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _trackService.DeleteTrack(id);
        }
    }
}
