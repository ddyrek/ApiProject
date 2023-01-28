using projektApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Infrastructure.FileStore
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        //Metoda CreateDirectory z klasy Direcctory, najpierw sprawdza czy Dirctory istnieje
        //nastepnie, jęsli nie ma tworzy Drectory
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
        //DirectoryWrapper - wstszyknięte w DependencyInjection do Kontenera IOC
    }
}
