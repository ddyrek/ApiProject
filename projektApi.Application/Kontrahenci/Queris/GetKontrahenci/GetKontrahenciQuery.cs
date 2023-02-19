using MediatR;
using projektApi.Application.Koontrahenci.Queris.GetKontrahenci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Queris.GetKontrahenci
{
    public class GetKontrahenciQuery : IRequest<KontrahenciVm>
    {
    }
}
