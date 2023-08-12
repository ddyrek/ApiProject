using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Psy.Queries.GetPiesDetail
{
    public class GetPiesDetailQuery : IRequest<PiesDetailVm>
    {
        public int PiesId { get; set; }
    }
}
