using AutoMapper;
using MediatR;
using projektApi.Application.Common.Mappings;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Wizyty.Commands.UpdateVisitCommand
{
    public class UpdateVisitCommand : IRequest<Unit>, IMapFrom<UpdateVisitCommand>
    {
        public int WizytaId { get; set; }
        public DateTime DataWizyty { get; set; }
        public DateTime GodzinaWizyty { get; set; }
        public string? Opis { get; set; }
        public decimal? Kwota { get; set; }
        public int PiesId { get; set; }
        //public Pies Pies { get; set; }

        public void Mapping(Profile profile)
        {
            //utworzenie mapy z commanda na Entity.Wizyty
            profile.CreateMap<UpdateVisitCommand, Wizyta>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.WizytaId))
                .ForMember(x => x.DataWizyty, map => map.MapFrom(src => src.DataWizyty))
                .ForMember(x => x.GodzinaWizyty, map => map.MapFrom(src => src.GodzinaWizyty))
                .ForMember(x => x.Opis, map => map.MapFrom(src => src.Opis))
                .ForMember(x => x.Kwota, map => map.MapFrom(src => src.Kwota))
                .ForMember(x => x.PiesId, map => map.MapFrom(src => src.PiesId))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            //.IgnoreAllNonExisting();
        }
    }
}
