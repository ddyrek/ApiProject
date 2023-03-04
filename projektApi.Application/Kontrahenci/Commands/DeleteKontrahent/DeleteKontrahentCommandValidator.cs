using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Commands.DeleteKontrahent
{
    internal class DeleteKontrahentCommandValidator : AbstractValidator<DeleteKontrahentCommand>
    {
        public DeleteKontrahentCommandValidator()
        {
            RuleFor(x => x.KontrahentId).NotEmpty().GreaterThan(0);
        }
    }
}

