﻿using CourierManagement.Data;
using CourierManagement.Training.Context;
using CourierManagement.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.Repositories
{
    public class PickupRepository : Repository<Pickup, int>,
        IPickupRepository
    {
        public PickupRepository(ITrainingContext context)
              : base((DbContext)context)
        {

        }
    }
}
