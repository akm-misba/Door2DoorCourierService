using CourierManagement.Data;
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
    public class HelpRepository : Repository<Help, int>,
        IHelpRepository
    {
        public HelpRepository(ITrainingContext context)
              : base((DbContext)context)
        {

        }
    }
}
