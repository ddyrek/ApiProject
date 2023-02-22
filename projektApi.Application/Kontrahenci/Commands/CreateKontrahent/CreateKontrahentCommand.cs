using AutoMapper;
using MediatR;
using projektApi.Application.Common.Mappings;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Commands.CreateKontrahent
{
    public class CreateKontrahentCommand : IRequest<int>, IMapFrom<CreateKontrahentCommand>  //do wersji z automaperem dołożono IMapFrom<T>
    {
        public string NazwaFirmy { get; set; }
        public string Ulica { get; set; }
        public string NumerBudynku { get; set; }
        public string NumerLokalu { get; set; }
        public string Nip { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime Created { get; set; }
        //public string ModifiedBy { get; set; }
        //public DateTime Modified { get; set; }
        //public int StatusId { get; set; }
        //public string InactivatedBy { get; set; }
        //public DateTime Inactivated { get; set; }

        public void Mapping(Profile profile)
        {
            //utworzenie mapy z commanda na Entity.Kontrahenta
            profile.CreateMap<CreateKontrahentCommand, Kontrahent>()
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
