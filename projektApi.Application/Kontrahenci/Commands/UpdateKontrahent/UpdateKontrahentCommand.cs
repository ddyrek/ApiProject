using AutoMapper;
using MediatR;
using projektApi.Application.Common.Mappings;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Commands.UpdateKontrahent
{
    public class UpdateKontrahentCommand : IRequest<Unit>, IMapFrom<UpdateKontrahentCommand>
    {
        public int KontrahentId { get; set; }
        public string NazwaFirmy { get; set; }
        public string Ulica { get; set; }
        public string NumerBudynku { get; set; }
        public string NumerLokalu { get; set; }
        public string Nip { get; set; }

        public void Mapping(Profile profile)
        {
            //utworzenie mapy z commanda na Entity.Kontrahenta
            profile.CreateMap<UpdateKontrahentCommand, Kontrahent>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.KontrahentId))
                .ForMember(x => x.NazwaFirmy, map => map.MapFrom(src => src.NazwaFirmy))
                .ForMember(x => x.Ulica, map => map.MapFrom(src => src.Ulica))
                .ForMember(x => x.NumerBudynku, map => map.MapFrom(src => src.NumerBudynku))
                .ForMember(x => x.NumerLokalu, map => map.MapFrom(src => src.NumerLokalu))
                .ForMember(x => x.Nip, map => map.MapFrom(src => src.Nip))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            //.IgnoreAllNonExisting();
        }
    }
}
