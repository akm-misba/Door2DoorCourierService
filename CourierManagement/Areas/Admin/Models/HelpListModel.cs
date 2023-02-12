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
    public class HelpListModel
    {
        private IHelpService _helpService;
        private IHttpContextAccessor _httpContextAccessor;
        public HelpListModel()
        {
            _helpService = Startup.AutofacContainer.Resolve<IHelpService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public HelpListModel(IHelpService helpService, IHttpContextAccessor httpContextAccessor)
        {
            _helpService = helpService;
            _httpContextAccessor = httpContextAccessor;
        }
        internal object GetHelps(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _helpService.GetHelps(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Id", "Customer_id", "Message", "Status" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {

                            record.Id.ToString(),
                            record.Customer_id.ToString(),
                            record.Message,
                            record.Status,
                            record.Id.ToString(),

                        }
                        ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _helpService.DeleteHelp(id);
        }
    }
}
