using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Commands.DeleteKontrahent
{
    public class DeleteKontrahentCommand : IRequest
    {
        public int KontrahentId { get; set; }
    }
}
