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
        public string NazwaFirmy { get; set; }
        public string? Ulica { get; set; }
        public string? NumerBudynku { get; set; }
        public string? NumerLokalu { get; set; }
        public string? Nip { get; set; }
        //public DateTime? Utworzono { get; set; }
        //public DateTime? Zmodyfikowano { get; set; }
        public ICollection<Klient> Klienci { get; set; }
        public ICollection<Pies> Psy { get; set; }
    }
}
