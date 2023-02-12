using Autofac;
using CourierManagement.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PickupListModel>().AsSelf();
            builder.RegisterType<TrackListModel>().AsSelf();
            base.Load(builder);
        }
    }
}
