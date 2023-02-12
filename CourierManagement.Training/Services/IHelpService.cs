using CourierManagement.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.Services
{
    public interface IHelpService
    {
        IList<Help> GetAllHelps();

        void AddHelp(Help help);

        (IList<Help> records, int total, int totalDisplay) GetHelps(int pageIndex,
            int pageSize, string searchText, string sortText);

        Help GetHelp(int id);
        void UpdateHelp(Help help);
        void DeleteHelp(int id);
    }
}
