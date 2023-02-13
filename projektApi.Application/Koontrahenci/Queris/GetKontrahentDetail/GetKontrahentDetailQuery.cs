using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Koontrahenci.Queris.GetKontrahentDetail
{
    public class GetKontrahentDetailQuery : IRequest<KontrahentDetailVm>
    {
        public int KontrahentId { get; set; }
    }
}
