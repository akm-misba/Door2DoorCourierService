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
    public class CourierService : ICourierService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public CourierService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }
        public void AddCourier(Courier courier)
        {
            if (courier == null)
                throw new invalidPerameterException("Courier details was not provided");

            _trainingUnitOfWork.Couriers.Add(
            _mapper.Map<Entities.Courier>(courier)
            );

            _trainingUnitOfWork.Save();
        }

        public void DeleteCourier(int id)
        {
            _trainingUnitOfWork.Couriers.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public IList<Courier> GetAllCouriers()
        {
            var courierEntities = _trainingUnitOfWork.Couriers.GetAll();
            var couriers = new List<Courier>();

            foreach (var entity in courierEntities)
            {
                var courier = _mapper.Map<Courier>(entity);
                couriers.Add(courier);
            }

            return couriers;
        }

        public Courier GetCourier(int id)
        {
            var courier = _trainingUnitOfWork.Couriers.GetById(id);

            if (courier == null) return null;

            return _mapper.Map<Courier>(courier);
        }

        public (IList<Courier> records, int total, int totalDisplay) GetCouriers(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var courierData = _trainingUnitOfWork.Couriers.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
               x => x.Name.Contains(searchText), sortText, string.Empty,
                pageIndex, pageSize);

            var resultData = (from courier in courierData.data
                              select _mapper.Map<Courier>(courier)).ToList();

            return (resultData, courierData.total, courierData.totalDisplay);
        }

        public void UpdateCourier(Courier courier)
        {
            if (courier == null)
                throw new InvalidOperationException("Courier is missing");


            var courierEntity = _trainingUnitOfWork.Couriers.GetById(courier.Id);

            if (courierEntity != null)
            {
                _mapper.Map(courier, courierEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find courier");
        }
    }
}
