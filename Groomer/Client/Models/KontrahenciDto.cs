namespace Groomer.Client.Models
{
    public class KontrahenciDto
    {
        public int Id { get; set; }
        public string NazwaFirmy { get; set; }
        public string Ulica { get; set; }
        public string NumerBudynku { get; set; }
        public string NumerLokalu { get; set; }
        public string Nip { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public int StatusId { get; set; }
        public string InactivatedBy { get; set; }
        public DateTime Inactivated { get; set; }
    }
}
