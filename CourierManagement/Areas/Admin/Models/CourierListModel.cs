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
    public class CourierListModel
    {
        private ICourierService _courierService;
        private IHttpContextAccessor _httpContextAccessor;
        public CourierListModel()
        {
            _courierService = Startup.AutofacContainer.Resolve<ICourierService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public CourierListModel(ICourierService courierService, IHttpContextAccessor httpContextAccessor)
        {
            _courierService = courierService;
            _httpContextAccessor = httpContextAccessor;
        }
        internal object GetCouriers(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _courierService.GetCouriers(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Id", "Name", "Email", "Password" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {

                            record.Id.ToString(),
                            record.Name,
                            record.Email,
                            record.Password,
                            record.Id.ToString(),

                        }
                        ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _courierService.DeleteCourier(id);
        }
    }
}
