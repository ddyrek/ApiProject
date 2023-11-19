using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Commands.DeleteKlient
{
    public class DeleteKlientCommandValidator : AbstractValidator<DeleteKlientCommand>
    {
        public DeleteKlientCommandValidator()
        {
            RuleFor(x => x.KlentId).NotEmpty().GreaterThan(0);
        }
    }
}
