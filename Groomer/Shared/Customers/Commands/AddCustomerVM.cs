using FluentValidation;
using System.ComponentModel.DataAnnotations;


namespace Groomer.Shared.Customers.Commands
{
    public class AddCustomerVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public int KontrahentId { get; set; }
        public AccountVm Accounts { get; set; } //tymczasowe
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

    public class AccountVm
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
    }
    //public class DogsVm //to zamiast AccountVm
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}