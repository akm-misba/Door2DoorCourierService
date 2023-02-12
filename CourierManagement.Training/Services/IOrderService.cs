using CourierManagement.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.Services
{
    public interface IOrderService
    {
        IList<Order> GetAllOrders();

        void AddOrder(Order order);

        (IList<Order> records, int total, int totalDisplay) GetOrders(int pageIndex,
            int pageSize, string searchText, string sortText);

        Order GetOrder(int id);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}
