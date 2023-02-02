using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Commands.DeleteKlient
{
    public class DeleteKlientCommand : IRequest
    {
        public int KlentId { get; set; }
    }
}
