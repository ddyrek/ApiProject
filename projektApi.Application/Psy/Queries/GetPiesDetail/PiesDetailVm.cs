using AutoMapper;
using projektApi.Application.Common.Mappings;
using projektApi.Domain.Entities;

namespace projektApi.Application.Psy.Queries.GetPiesDetail
{
    public class PiesDetailVm : IMapFrom<Pies>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string? Description { get; set; }
        public int KlientId { get; set; }
        public int KontrahentId { get; set; }
        //public Klient Klient { get; set; }
        //public Kontrahent Kontrahent { get; set; }
        //public ICollection<Wizyta> Wizyty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pies, PiesDetailVm>();
        }
    }
}