using CourierManagement.Data;
using CourierManagement.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.Repositories
{
    public interface IPickupRepository : IRepository<Pickup, int>
    {
    }
}
