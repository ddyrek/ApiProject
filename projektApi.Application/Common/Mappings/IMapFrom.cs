using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Common.Mappings
{
    //ten interface będzie wykorzystywany w każdym ViewModelu
    //do tego aby wskazac z jakiego entity jest budowany dany ViewModel
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
