using AutoMapper;
using projektApi.Application.Common.Mappings;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Queris.GetKlienci
{
    public class KlientDto : IMapFrom<Klient>
    {
        public int Id { get; set; }
        public string KlientName { get; set; }
        public string PhoneNumber { get; set; }
        public int KontrahentId { get; set; }
        public Kontrahent Kontrahent { get; set; }
        //public ICollection<Pies> Psy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public int StatusId { get; set; }
        public string InactivatedBy { get; set; }
        public DateTime Inactivated { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Klient, KlientDto>();
               //    .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
              //     .ForMember(x => x.NazwaFirmy, map => map.MapFrom(src => src.NazwaFirmy));
        }
    }
}
