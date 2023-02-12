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
            //tworzymy mapę jak w interfejsie
            //jeśli wszystkie property z naszego entity,
            //będą dokładnie odpowiadać nazwom elementom we Vm, wtedy
            //nie musimy nic robić i wystarczy profile.CreateMap<Klient, KlientDetailVm>();
            //a jeśli  nie mamy tych elementów we Vm tak samo nazwanych, to wtedy,
            //potrzebujemy pokazać jak będzie dokładnie wygladać mapowanie, tak jak tu .ForMeber
            //po przez .ForMember wskazujemy do jakiego elementu będziemy mapować a nastepnie wybieramy żródło z jakiego
            profile.CreateMap<Klient, KlientDetailVm>()
                .ForMember(d => d.FullName, map => map.MapFrom(src => src.KlientName.ToString()))
                //.ForMember(d => d.LastPiesName, map => map.MapFrom(src => src.Psy.OrderByDescending(p => p.Name).FirstOrDefault().Name)); //gdy nie uzywamy  castomowego Resolvera
                .ForMember(d => d.LastPiesName, map => map.MapFrom<LastPiesNameResolver>());
            //.ForMemeber(d => d.Name, Mapper => map.Ignore());  //ignorowanie Name Propertis w mapowaniu
            //.ForAllOtherMemeber(d => d.Ignore()); //ignorowanie wszystkich pozostałych Proprtis  w mapowaniu
            // ForAllOtherMemeber - jest to często wykorzystywane sczególnie w Commands i w Updatach
            // żeby updatowane były tylko te elementy które wskażemy a nie wszystkie
        }

        //automamper zazwyczaj radzi sobie z niespodzieawanymi nullami w Propertis, ale
        //jęsli nie jesteśmy pewnie jak sobie poradzi automaper z mapowaniem dla złorzonego elementu
        //takiego jak LastPiesName, możemy urzyć IValueRessolver,
        //np. gdy Klient moze nie miec jeszcze zadnego Psa,
        //lub Pies może nie miec którgoś pola po którym sortujemy np.
        //tu Name - Psy.OrderByDescending(p => p.Name) i takie mapowanie mogło by wysypać błąd
        //lub gdy mamy warunkowe Property (jakaś wartość property zależna jest od wartości innego property)
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
