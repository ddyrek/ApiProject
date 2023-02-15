using AutoMapper;
using projektApi.Application.Common.Mappings;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Koontrahenci.Queris.GetKontrahenci
{
    public class KontrahentDto : IMapFrom<Kontrahent>
    {
        public int Id { get; set; }
        public string NazwaFirmy { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Kontrahent, KontrahentDto>();
        //        .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
        //        .ForMember(x => x.NazwaFirmy, map => map.MapFrom(src => src.NazwaFirmy));
        }
    }
}
