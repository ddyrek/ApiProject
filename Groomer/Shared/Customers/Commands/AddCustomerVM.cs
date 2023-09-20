using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Customers.Commands
{
    public class AddCustomerVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public int KontrahentId { get; set; }
        //public ContractorVM Contractors { get; set; }
    }

    public class AddCustomerValidator : AbstractValidator<AddCustomerVM>
    {
        public AddCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20).WithMessage("Name needs to be at least 10 chars!");
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(20);
            RuleFor(x => x.PhoneNumber).MaximumLength(20);
            RuleFor(x => x.KontrahentId).NotEmpty();
        }
    }

    //public class ContractorVM
    //{

    //}
}