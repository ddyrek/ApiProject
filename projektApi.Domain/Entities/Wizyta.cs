using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Domain.Entities
{
    public class Wizyta
    {
        public int Id { get; set; }
        public DateTime Data_wizyty { get; set; }
        public DateTime Godzina_wizyty { get; set; }
        public long Opis { get; set; }
        public double? Kwota { get; set; }
        public int Pies_id { get; set; }
        public Pies Pies { get; set; }
    }
}
