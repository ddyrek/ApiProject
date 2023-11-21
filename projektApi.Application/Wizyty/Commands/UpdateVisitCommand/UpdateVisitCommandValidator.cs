using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Wizyty.Commands.UpdateVisitCommand
{
    public class UpdateVisitCommandValidator : AbstractValidator<UpdateVisitCommand>
    {
        public UpdateVisitCommandValidator()
        {
            RuleFor(x => x.WizytaId).NotEmpty().GreaterThan(0);//czy ma to być?
            RuleFor(x => x.DataWizyty).NotEmpty();
            RuleFor(x => x.GodzinaWizyty).NotEmpty();
            RuleFor(x => x.Opis).MaximumLength(40).NotEmpty();
            RuleFor(x => x.Kwota).NotNull();
            RuleFor(x => x.PiesId).NotNull();
        }
    }
}
