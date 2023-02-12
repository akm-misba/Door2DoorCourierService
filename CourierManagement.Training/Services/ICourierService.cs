using CourierManagement.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.Services
{
    public interface ICourierService
    {
        IList<Courier> GetAllCouriers();

        void AddCourier(Courier courier);

        (IList<Courier> records, int total, int totalDisplay) GetCouriers(int pageIndex,
            int pageSize, string searchText, string sortText);

        Courier GetCourier(int id);
        void UpdateCourier(Courier courier);
        void DeleteCourier(int id);
    }
}
