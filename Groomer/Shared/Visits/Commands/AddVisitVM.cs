using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Groomer.Shared.Visits.Commands
{
    public class AddVisitVM
    {
        public int Id { get; set; }
        public DateTime DataWizyty { get; set; }
        public DateTime GodzinaWizyty { get; set; }
        public string? Opis { get; set; }
        public decimal? Kwota { get; set; }
        public int PiesId { get; set; }
        //public Pies Pies { get; set; }
    }

    public class AddVisitValidator : AbstractValidator<AddVisitVM>
    {
        public AddVisitValidator()
        {
            RuleFor(x => x.DataWizyty).NotEmpty();
            RuleFor(x => x.GodzinaWizyty).NotEmpty();
            RuleFor(x => x.Opis).MaximumLength(60).WithMessage("Description needs to be at least 60 chars!");
            RuleFor(x => x.PiesId).NotEmpty();
        }
    }

}
