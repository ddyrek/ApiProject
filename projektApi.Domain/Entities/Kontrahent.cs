using projektApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Domain.Entities
{
    public class Kontrahent : AuditableEntity
    {
        public string? Nazwa_firmy { get; set; }
        public string? Ulica { get; set; }
        public string? Numer_budynku { get; set; }
        public string? Numer_lokalu { get; set; }
        public decimal? Nip { get; set; }
        //public DateTime? Utworzono { get; set; }
        //public DateTime? Zmodyfikowano { get; set; }
        public ICollection<Klient> Klienci { get; set; }
        public ICollection<Pies> Psy { get; set; }
    }
}
