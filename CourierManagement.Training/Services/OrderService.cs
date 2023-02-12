using AutoMapper;
using CourierManagement.Common.Utilities;
using CourierManagement.Training.BusinessObjects;
using CourierManagement.Training.Exceptions;
using CourierManagement.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.Services
{
    public class OrderService : IOrderService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public OrderService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }

        public void AddOrder(Order order)
        {
            if (order == null)
                throw new invalidPerameterException("Order details was not provided");

            _trainingUnitOfWork.Orders.Add(
            _mapper.Map<Entities.Order>(order)
            );

            _trainingUnitOfWork.Save();
        }

        public void DeleteOrder(int id)
        {
            _trainingUnitOfWork.Orders.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public IList<Order> GetAllOrders()
        {
            var orderEntities = _trainingUnitOfWork.Orders.GetAll();
            var orders = new List<Order>();

            foreach (var entity in orderEntities)
            {
                var order = _mapper.Map<Order>(entity);
                orders.Add(order);
            }

            return orders;
        }

        public Order GetOrder(int id)
        {
            var order = _trainingUnitOfWork.Orders.GetById(id);

            if (order == null) return null;

            return _mapper.Map<Order>(order);
        }

        public (IList<Order> records, int total, int totalDisplay) GetOrders(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var orderData = _trainingUnitOfWork.Orders.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
              x => x.From.Contains(searchText), sortText, string.Empty,
               pageIndex, pageSize);

            var resultData = (from order in orderData.data
                              select _mapper.Map<Order>(order)).ToList();

            return (resultData, orderData.total, orderData.totalDisplay);
        }

        public void UpdateOrder(Order order)
        {
            if (order == null)
                throw new InvalidOperationException("Order is missing");


            var orderEntity = _trainingUnitOfWork.Orders.GetById(order.Id);

            if (orderEntity != null)
            {
                _mapper.Map(order, orderEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find Order");
        }
    }
}
