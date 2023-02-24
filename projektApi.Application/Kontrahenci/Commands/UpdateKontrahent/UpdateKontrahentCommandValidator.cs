using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Commands.UpdateKontrahent
{
    public class UpdateKontrahentCommandValidator : AbstractValidator<UpdateKontrahentCommand>
    {
        public UpdateKontrahentCommandValidator()
        {
            RuleFor(x => x.KontrahentId).NotEmpty().GreaterThan(0);//czy ma to być?
            RuleFor(x => x.NazwaFirmy).NotEmpty().MaximumLength(32);
            RuleFor(x => x.Ulica).MaximumLength(32).NotEmpty();
            RuleFor(x => x.NumerBudynku).MaximumLength(5).NotEmpty();
            RuleFor(x => x.NumerLokalu).MaximumLength(10);
            RuleFor(x => x.Nip).MaximumLength(10);
        }
    }
}
