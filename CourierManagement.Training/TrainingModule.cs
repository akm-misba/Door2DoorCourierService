using Autofac;
using CourierManagement.Training.Context;
using CourierManagement.Training.Repositories;
using CourierManagement.Training.Services;
using CourierManagement.Training.UnitOfWorks;
using System;

namespace CourierManagement.Training
{
    public class TrainingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public TrainingModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrainingContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<TrainingContext>().As<ITrainingContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CourierRepository>().As<ICourierRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CourierService>().As<ICourierService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<HelpRepository>().As<IHelpRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<HelpService>().As<IHelpService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderRepository>().As<IOrderRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PickupRepository>().As<IPickupRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<PickupService>().As<IPickupService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TrackRepository>().As<ITrackRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<TrackService>().As<ITrackService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
