﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Dogs.Queries.AllDogsQuery
{
    public class PsyList
    {
        public List<DogsForListVm> Psy { get; set; }
    }
    public class DogsForListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string? Description { get; set; }
        public int KlientId { get; set; }
        public int KontrahentId { get; set; }
        //public Klient Klient { get; set; }
        //public Kontrahent Kontrahent { get; set; }
        //public ICollection<Wizyta> Wizyty
    }

}
