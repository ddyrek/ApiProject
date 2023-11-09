using AutoMapper;
using projektApi.Application.Common.Mappings;
using projektApi.Application.Koontrahenci.Queris.GetKontrahenci;
using projektApi.Domain.Entities;

namespace projektApi.Application.Psy.Queries.GetPsy
{
    public class PiesDto : IMapFrom<Pies>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string? Description { get; set; }
        public int KlientId { get; set; }
        public int KontrahentId { get; set; }
        public Klient Klient { get; set; }
        //public Kontrahent Kontrahent { get; set; }
        //public ICollection<Wizyta> Wizyty

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pies, PiesDto>();
            //        .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
            //        .ForMember(x => x.NazwaFirmy, map => map.MapFrom(src => src.NazwaFirmy));
        }
    }
}