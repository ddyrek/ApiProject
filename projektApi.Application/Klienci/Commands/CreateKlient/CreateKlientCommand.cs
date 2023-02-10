using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Commands.CreateKlient
{
    public class CreateKlientCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public int KontrahentId { get; set; }
    }
}
