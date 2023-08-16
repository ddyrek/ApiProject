using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Visits.Queries.AllVisitsQuery
{
    public class VisitForListVm
    {
        public int Id { get; set; }
        public DateTime DataWizyty { get; set; }
        public DateTime GodzinaWizyty { get; set; }
        public string? Opis { get; set; }
        public decimal? Kwota { get; set; }
        public int PiesId { get; set; }
        //public Pies Pies { get; set; }
    }
}
