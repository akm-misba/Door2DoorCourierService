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
    public class CustomerService : ICustomerService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public CustomerService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }
        public void AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new invalidPerameterException("Customer details was not provided");

            _trainingUnitOfWork.Customers.Add(
            _mapper.Map<Entities.Customer>(customer)
            );

            _trainingUnitOfWork.Save();
        }

        public void DeleteCustomer(int id)
        {
            _trainingUnitOfWork.Customers.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public IList<Customer> GetAllCustomers()
        {
            var customerEntities = _trainingUnitOfWork.Customers.GetAll();
            var customers = new List<Customer>();

            foreach (var entity in customerEntities)
            {
                var customer = _mapper.Map<Customer>(entity);
                customers.Add(customer);
            }

            return customers;
        }

        public Customer GetCustomer(int id)
        {
            var customer = _trainingUnitOfWork.Customers.GetById(id);

            if (customer == null) return null;

            return _mapper.Map<Customer>(customer);
        }

        public (IList<Customer> records, int total, int totalDisplay) GetCustomers(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var customerData = _trainingUnitOfWork.Customers.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
               x => x.Name.Contains(searchText), sortText, string.Empty,
                pageIndex, pageSize);

            var resultData = (from customer in customerData.data
                              select _mapper.Map<Customer>(customer)).ToList();

            return (resultData, customerData.total, customerData.totalDisplay);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new InvalidOperationException("Customer is missing");


            var customerEntity = _trainingUnitOfWork.Customers.GetById(customer.Id);

            if (customerEntity != null)
            {
                _mapper.Map(customer, customerEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find customer");
        }
    }
}
