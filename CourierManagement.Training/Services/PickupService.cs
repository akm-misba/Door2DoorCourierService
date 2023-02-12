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
    public class PickupService : IPickupService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public PickupService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }
        public void AddPickup(Pickup pickup)
        {
            if (pickup == null)
                throw new invalidPerameterException("Pickup details was not provided");

            _trainingUnitOfWork.Pickups.Add(
            _mapper.Map<Entities.Pickup>(pickup)
            );

            _trainingUnitOfWork.Save();
        }

        public void DeletePickup(int id)
        {
            _trainingUnitOfWork.Pickups.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public IList<Pickup> GetAllPickups()
        {
            var pickupEntities = _trainingUnitOfWork.Pickups.GetAll();
            var pickups = new List<Pickup>();

            foreach (var entity in pickupEntities)
            {
                var pickup = _mapper.Map<Pickup>(entity);
                pickups.Add(pickup);
            }

            return pickups;
        }

        public Pickup GetPickup(int id)
        {
            var pickup = _trainingUnitOfWork.Pickups.GetById(id);

            if (pickup == null) return null;

            return _mapper.Map<Pickup>(pickup);
        }

        public (IList<Pickup> records, int total, int totalDisplay) GetPickups(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var pickupData = _trainingUnitOfWork.Pickups.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
               x => x.DateAndTime.Contains(searchText), sortText, string.Empty,
                pageIndex, pageSize);

            var resultData = (from pickup in pickupData.data
                              select _mapper.Map<Pickup>(pickup)).ToList();

            return (resultData, pickupData.total, pickupData.totalDisplay);
        }

        public void UpdatePickup(Pickup pickup)
        {
            if (pickup == null)
                throw new InvalidOperationException("Pickup is missing");


            var pickupEntity = _trainingUnitOfWork.Pickups.GetById(pickup.Id);

            if (pickupEntity != null)
            {
                _mapper.Map(pickup, pickupEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find pickup");
        }
    }
}
