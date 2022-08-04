using System.ComponentModel.DataAnnotations;

namespace Zadanie1.Models
{
    public class Employer
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Nip { get; set; }
        public string StatusVat { get; set; }
        public string Regon { get; set; }
        public string ResidenceAddress { get; set; }
        public string RegistrationLegalDate { get; set; }
    }
}
