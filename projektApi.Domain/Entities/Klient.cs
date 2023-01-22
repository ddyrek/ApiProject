using projektApi.Domain.Common;
using projektApi.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Domain.Entities
{
    public class Klient : AuditableEntity //dziedziczenie by dodac kto i kiedy modyfikował rekord w bazie
    {
        public PersonName KlientName { get; set; }
        //public string Name { get; set; }
        //public string Surname { get; set; }
        public string Phone_number { get; set; }
        public int Kod_Kon_Id { get; set; }
        public Kontrahent Kontrahent { get; set; }
        public ICollection<Pies> Psy { get; set; } //ICollection po stornie jeden (klient) do wielu (pies) + public Klient Klient{get; set}
                                                    //Przy wiele do wiele ICollection po bu stronach, jesl inny ORM niz EF Core, musi być osrednia tabela
                                                    //Przy jeden do jeden  np pies pies po obu stronach
                                                    //Dla metody OnDelete wazny jest umiejscowinie klucza obcego (IdKlient) jesli cascad e
                                                    //Pamietamy że w EF enum DeleteBehavior moze mieć 3 wartości cascade, restrict, set null)
    }
}
