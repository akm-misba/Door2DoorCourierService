using CourierManagement.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.Services
{
    public interface IPickupService
    {
        IList<Pickup> GetAllPickups();

        void AddPickup(Pickup pickup);

        (IList<Pickup> records, int total, int totalDisplay) GetPickups(int pageIndex,
            int pageSize, string searchText, string sortText);

        Pickup GetPickup(int id);
        void UpdatePickup(Pickup pickup);
        void DeletePickup(int id);
    }
}
