using AutoMapper;
using projektApi.Application.Common.Mappings;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Queris.GetKlientDetail
{
    public class KlientDetailVm : IMapFrom<Klient> //IMapFrom<T> dołozone po dodaniu Automapera
    {
        public string FullName { get; set; }
        public string LastPiesName { get; set; }

        //generowanie mapy Automappera, musimy też dodać w Handlerze interfejs IMapper
        //dzięki automapperowi mamy dostęp w jednym miejscu
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Klient, KlientDetailVm>()
                .ForMember(d => d.FullName, map => map.MapFrom(src => src.KlientName.ToString()))
                .ForMember(d => d.LastPiesName, map => map.MapFrom<LastPiesNameResolver>());
            //.ForMemeber(d => d.Name, Mapper => map.Ignore());  //ignorowanie Name Propertis w mapowaniu
            //.ForAllOtherMemeber(d => d.Ignore()); //ignorowanie wszystkich pozostałych Proprtis  w mapowaniu
            // ForAllOtherMemeber - jest to często wykorzystywane sczególnie w Commands i w Updatach
            // żeby updatowane były tylko te elementy które wskażemy a nie wszystkie
        }

        private class LastPiesNameResolver : IValueResolver<Klient, object, string>
        {
            public string Resolve(Klient source, object destination, string destMember, ResolutionContext context)
            {
                //sprawdzamy czy Psy nie są nullem i czy mój Pies w obiekcie Psy ma coś wpisanego
                //jeżeli ma jakiegoś psa to pobieramy
                //jęśli nie zwracamy pustego stringa
                if (source.Psy is not null && source.Psy.Any())
                {
                    var lastPies = source.Psy.OrderByDescending(p => p.Name).FirstOrDefault();
                    return lastPies.Name;
                }
                return string.Empty;
            }
        }
    }
}
