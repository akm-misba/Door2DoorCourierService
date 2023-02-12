using CourierManagement.Data;
using CourierManagement.Training.Context;
using CourierManagement.Training.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public ICourierRepository Couriers { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IHelpRepository Helps { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IPickupRepository Pickups { get; private set; }
        public ITrackRepository Tracks { get; private set; }

        public TrainingUnitOfWork(ITrainingContext context,
            ICourierRepository couriers,
            ICustomerRepository customers,
            IHelpRepository helps,
            IOrderRepository orders,
            IPickupRepository pickups,
            ITrackRepository tracks
            ) : base((DbContext)context)
        {
            Couriers = couriers;
            Customers = customers;
            Helps = helps;
            Orders = orders;
            Pickups = pickups;
            Tracks = tracks;
        }
    }
}
