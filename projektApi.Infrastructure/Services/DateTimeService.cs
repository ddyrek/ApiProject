using projektApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        //jest to interfejs w którym mogę konfigurować potrzebny czas (.ToLokalTime, .ToUniversalTime etc.)
        //dzięki tej konstrukcji mamy pewność że każdy DateTime.Now w aplikacji jest tym samym DateTime.Now tzn. czas systemowy
        public DateTime Now => DateTime.Now;
    }
}
