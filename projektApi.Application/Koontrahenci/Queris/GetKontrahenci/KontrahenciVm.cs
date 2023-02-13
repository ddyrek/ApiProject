using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Koontrahenci.Queris.GetKontrahenci
{
    public class KontrahenciVm
    {
        ICollection<KontrahentDto> Kontrahenci { get; set; }
    }
}
