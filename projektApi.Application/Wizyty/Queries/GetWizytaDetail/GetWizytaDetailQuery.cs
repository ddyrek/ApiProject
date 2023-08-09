using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Wizyty.Queries.GetWizytaDetail
{
    public class GetWizytaDetailQuery : IRequest<WizytaDetailVm>
    {
        public int WizytaId { get; set; }
    }
}
