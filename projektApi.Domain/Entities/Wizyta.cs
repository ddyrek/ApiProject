﻿using System;
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
        public string Opis { get; set; }
        public decimal? Kwota { get; set; }
        public int PiesId { get; set; }
        public Pies Pies { get; set; }
    }
}
