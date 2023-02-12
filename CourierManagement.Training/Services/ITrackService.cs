using CourierManagement.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.Services
{
    public interface ITrackService
    {
        IList<Track> GetAllTracks();

        void AddTrack(Track track);

        (IList<Track> records, int total, int totalDisplay) GetTracks(int pageIndex,
            int pageSize, string searchText, string sortText);

        Track GetTrack(int id);
        void UpdateTrack(Track track);
        void DeleteTrack(int id);
    }
}
