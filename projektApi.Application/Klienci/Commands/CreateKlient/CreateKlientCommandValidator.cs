using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Commands.CreateKlient
{
    public class CreateKlientCommandValidator : AbstractValidator<CreateKlientCommand>
    {
        public CreateKlientCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(20);
            RuleFor(x => x.PhoneNumber).MaximumLength(20);
            RuleFor(x => x.KontrahentId).NotEmpty();
        }
        //po stronie Projekt.Applicaction/DependencyInjection należy dodać serwis
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //należy wtedy tam pobrac paczke FluentValidation.Extension.DependencyInjection
    }
}
