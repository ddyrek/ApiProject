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
        public string Ulica { get; set; }
        public string NumerBudynku { get; set; }
        public string NumerLokalu { get; set; }
        public string Nip { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public int StatusId { get; set; }
        public string InactivatedBy { get; set; }
        public DateTime Inactivated { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Kontrahent, KontrahentDto>();
        //        .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
        //        .ForMember(x => x.NazwaFirmy, map => map.MapFrom(src => src.NazwaFirmy));
        }
    }
}
