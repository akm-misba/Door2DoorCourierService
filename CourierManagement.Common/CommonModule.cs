using Autofac;
using CourierManagement.Common.Utilities;
using System;

namespace CourierManagement.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>()
                .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
