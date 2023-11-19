using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Wizyty.Commands.DeleteVisitCommand
{
    public class DeleteVisitCommand : IRequest
    {
        public int VisitId { get; set; }
    }
}
