using projektApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Domain.Entities
{
    public class Pies : AuditableEntity
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Description { get; set; }
        public int Klient_Id { get; set; }
        public int? Kod_Kon_Id { get; set; } // ? - Nullable, Delete Behaviuor (OnDelete) ustawiony na Set Null
        public Klient Klient { get; set; }
        public Kontrahent Kontrahent { get; set; }
        public ICollection<Wizyta> Wizyty { get; set; }
    }
}
