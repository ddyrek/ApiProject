using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Queris.GetKlientDetail
{
    // w tej klasie zawarty jest cały kontrakt
    // bedzie on nazywany GetKlientDetailQuery
    // żeby znaleźć Klienta bedzie on wykozystywał KlientId
    // i wzamian zwrócimy KlientDaetailVm
    public class GetKlientDetailQuery : IRequest<KlientDetailVm>
    {
        public int KlientId { get; set; }
    }
}
