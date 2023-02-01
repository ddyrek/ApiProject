using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Queris.GetKlienci
{
    public class KlienciVm
    {
        ICollection<KlientDto> Klienci { get; set; }
    }
}
