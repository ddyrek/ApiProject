using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Commands.CreateKontrahent
{
    public class CreateKontrahentCommandValidator : AbstractValidator<CreateKontrahentCommand>
    {
        public CreateKontrahentCommandValidator()
        {
            RuleFor(x => x.NazwaFirmy).NotEmpty().MaximumLength(32);
            RuleFor(x => x.Ulica).MaximumLength(32).NotEmpty();
            RuleFor(x => x.NumerBudynku).MaximumLength(5).NotEmpty();
            RuleFor(x => x.NumerLokalu).MaximumLength(10);
            RuleFor(x => x.Nip).MaximumLength(10);
            RuleFor(x => x.StatusId).NotEmpty();
        }
        //po stronie Projekt.Applicaction/DependencyInjection należy dodać serwis
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //należy wtedy tam pobrac paczke FluentValidation.Extension.DependencyInjection
    }
}
