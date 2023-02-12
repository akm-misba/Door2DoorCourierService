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
    public class HelpService : IHelpService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public HelpService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }
        public void AddHelp(Help help)
        {
            if (help == null)
                throw new invalidPerameterException("Help details was not provided");

            _trainingUnitOfWork.Helps.Add(
            _mapper.Map<Entities.Help>(help)
            );

            _trainingUnitOfWork.Save();
        }

        public void DeleteHelp(int id)
        {
            _trainingUnitOfWork.Helps.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public IList<Help> GetAllHelps()
        {
            var helpEntities = _trainingUnitOfWork.Helps.GetAll();
            var helps = new List<Help>();

            foreach (var entity in helpEntities)
            {
                var help = _mapper.Map<Help>(entity);
                helps.Add(help);
            }

            return helps;
        }

        public Help GetHelp(int id)
        {
            var help = _trainingUnitOfWork.Helps.GetById(id);

            if (help == null) return null;

            return _mapper.Map<Help>(help);
        }

        public (IList<Help> records, int total, int totalDisplay) GetHelps(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var helpData = _trainingUnitOfWork.Helps.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
                x => x.Status.Contains(searchText), sortText, string.Empty,
                 pageIndex, pageSize);

            var resultData = (from help in helpData.data
                              select _mapper.Map<Help>(help)).ToList();

            return (resultData, helpData.total, helpData.totalDisplay);
        }

        public void UpdateHelp(Help help)
        {
            if (help == null)
                throw new InvalidOperationException("Help is missing");


            var helpEntity = _trainingUnitOfWork.Helps.GetById(help.Id);

            if (helpEntity != null)
            {
                _mapper.Map(help, helpEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find help");
        }
    }
}
