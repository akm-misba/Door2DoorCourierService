using CourierManagement.Data;
using CourierManagement.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        ICourierRepository Couriers { get; }
        ICustomerRepository Customers { get; }
        IHelpRepository Helps { get; }
        IOrderRepository Orders { get; }
        IPickupRepository Pickups { get; }
        ITrackRepository Tracks { get; }
    }
}
