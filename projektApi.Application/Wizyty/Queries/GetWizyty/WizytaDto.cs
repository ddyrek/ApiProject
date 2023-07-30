using AutoMapper;
using projektApi.Application.Common.Mappings;
using projektApi.Domain.Entities;

namespace projektApi.Application.Wizyty.Queries.GetWizyty
{
    public class WizytaDto : IMapFrom<Wizyta>
    {
        public int Id { get; set; }
        public DateTime DataWizyty { get; set; }
        public DateTime GodzinaWizyty { get; set; }
        public string? Opis { get; set; }
        public decimal? Kwota { get; set; }
        public int PiesId { get; set; }
        //public Pies Pies { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Wizyta, WizytaDto>();
            //        .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
            //        .ForMember(x => x.NazwaFirmy, map => map.MapFrom(src => src.NazwaFirmy));
        }
    }
}