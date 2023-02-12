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
    public class PickupListModel
    {
        private IPickupService _pickupService;
        private IHttpContextAccessor _httpContextAccessor;
        public PickupListModel()
        {
            _pickupService = Startup.AutofacContainer.Resolve<IPickupService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public PickupListModel(IPickupService pickupService, IHttpContextAccessor httpContextAccessor)
        {
            _pickupService = pickupService;
            _httpContextAccessor = httpContextAccessor;
        }
        internal object GetPickups(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _pickupService.GetPickups(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Id", "Order_id", "Courier_id", "DateAndTime"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {

                            record.Id.ToString(),
                            record.Order_id.ToString(),
                            record.Courier_id.ToString(),
                            record.DateAndTime,
                            record.Id.ToString(),

                        }
                        ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _pickupService.DeletePickup(id);
        }
    }
}
