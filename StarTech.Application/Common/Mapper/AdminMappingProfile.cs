using AutoMapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Common.Mapper
{
    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile()
        {
            //CreateMap<BusRegistrationNo, BusRegistrationDTO>()
            //    .ForMember(d => d.RegistrationNo, o => o.MapFrom(s => s.registration_number))
            //    .ForMember(d => d.CoachType, o => o.MapFrom(s => s.coach_type))
            //    .ReverseMap();


            //CreateMap<BusCounter, BusCounterDTO>().ReverseMap();
        }

    }
}
