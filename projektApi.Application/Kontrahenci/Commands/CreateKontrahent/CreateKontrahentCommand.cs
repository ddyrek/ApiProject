using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Commands.CreateKontrahent
{
    public class CreateKontrahentCommand : IRequest<int>
    {
        public string NazwaFirmy { get; set; }
        public string Ulica { get; set; }
        public string NumerBudynku { get; set; }
        public string NumerLokalu { get; set; }
        public string Nip { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime Created { get; set; }
        //public string ModifiedBy { get; set; }
        //public DateTime Modified { get; set; }
        //public int StatusId { get; set; }
        //public string InactivatedBy { get; set; }
        //public DateTime Inactivated { get; set; }
    }
}
