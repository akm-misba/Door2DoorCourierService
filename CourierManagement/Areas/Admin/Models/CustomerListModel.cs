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
    public class CustomerListModel
    {
        private ICustomerService _customerService;
        private IHttpContextAccessor _httpContextAccessor;
        public CustomerListModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public CustomerListModel(ICustomerService customerService, IHttpContextAccessor httpContextAccessor)
        {
            _customerService = customerService;
            _httpContextAccessor = httpContextAccessor;
        }
        internal object GetCustomers(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _customerService.GetCustomers(
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
            _customerService.DeleteCustomer(id);
        }
    }
}
