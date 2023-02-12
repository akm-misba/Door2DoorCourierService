using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = CourierManagement.Training.Entities;
using BO = CourierManagement.Training.BusinessObjects;

namespace CourierManagement.Training.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<EO.Courier, BO.Courier>().ReverseMap();
            CreateMap<EO.Customer, BO.Customer>().ReverseMap();
            CreateMap<EO.Help, BO.Help>().ReverseMap();
            CreateMap<EO.Order, BO.Order>().ReverseMap();
            CreateMap<EO.Pickup, BO.Pickup>().ReverseMap();
            CreateMap<EO.Track, BO.Track>().ReverseMap();
        }
        
    }
}
