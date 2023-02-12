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
    public class TrackService : ITrackService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public TrackService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }
        public void AddTrack(Track track)
        {
            if (track == null)
                throw new invalidPerameterException("Track details was not provided");

            _trainingUnitOfWork.Tracks.Add(
            _mapper.Map<Entities.Track>(track)
            );

            _trainingUnitOfWork.Save();
        }

        public void DeleteTrack(int id)
        {
            _trainingUnitOfWork.Tracks.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public IList<Track> GetAllTracks()
        {
            var trackEntities = _trainingUnitOfWork.Tracks.GetAll();
            var tracks = new List<Track>();

            foreach (var entity in trackEntities)
            {
                var track = _mapper.Map<Track>(entity);
                tracks.Add(track);
            }

            return tracks;
        }

        public Track GetTrack(int id)
        {
            var track = _trainingUnitOfWork.Tracks.GetById(id);

            if (track == null) return null;

            return _mapper.Map<Track>(track);
        }

        public (IList<Track> records, int total, int totalDisplay) GetTracks(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var trackData = _trainingUnitOfWork.Tracks.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
               x => x.Status.Contains(searchText), sortText, string.Empty,
                pageIndex, pageSize);

            var resultData = (from track in trackData.data
                              select _mapper.Map<Track>(track)).ToList();

            return (resultData, trackData.total, trackData.totalDisplay);
        }

        public void UpdateTrack(Track track)
        {
            if (track == null)
                throw new InvalidOperationException("Track is missing");


            var trackEntity = _trainingUnitOfWork.Tracks.GetById(track.Id);

            if (trackEntity != null)
            {
                _mapper.Map(track, trackEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find track");
        }
    }
}
