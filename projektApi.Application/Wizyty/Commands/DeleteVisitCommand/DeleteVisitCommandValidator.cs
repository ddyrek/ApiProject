using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Wizyty.Commands.DeleteVisitCommand
{
    public class DeleteVisitCommandValidator : AbstractValidator<DeleteVisitCommand>
    {
        public DeleteVisitCommandValidator()
        {
            RuleFor(x => x.VisitId).NotEmpty().GreaterThan(0);
        }
    }
}
