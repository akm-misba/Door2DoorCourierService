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
    public class OrderListForCourier
    {
        private IOrderService _orderService;
        private IHttpContextAccessor _httpContextAccessor;
        public OrderListForCourier()
        {
            _orderService = Startup.AutofacContainer.Resolve<IOrderService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public OrderListForCourier(IOrderService orderService, IHttpContextAccessor httpContextAccessor)
        {
            _orderService = orderService;
            _httpContextAccessor = httpContextAccessor;
        }
        internal object GetOrders(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _orderService.GetOrders(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Id", "Customer_id", "From", "To" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {

                            record.Id.ToString(),
                            record.Customer_id.ToString(),
                            record.From,
                            record.To,
                            record.Source_to_office,
                            record.Office_to_destination,
                            record.Id.ToString(),

                        }
                        ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _orderService.DeleteOrder(id);
        }
    }
}
