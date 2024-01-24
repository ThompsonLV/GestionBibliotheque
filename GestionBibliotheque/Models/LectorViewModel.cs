using System.ComponentModel.DataAnnotations;

namespace GestionBibliotheque.Models
{
    public class LectorViewModel
    {
        public int Id { get; set; }
        public int? AdressId { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(30, ErrorMessage = "Le nom est trop long")]
        public string Firstname { get; set; } = null!;

        [Required(ErrorMessage = "Le prénom est requis")]
        [StringLength(30, ErrorMessage = "Le prénom est trop long")]
        public string Lastname { get; set; } = null!;

        [Required(ErrorMessage = "Le mail est requis")]
        [EmailAddress(ErrorMessage = "Le mail n'est pas valide")]
        public string Email { get; set; } = null!;

        [StringLength(10, ErrorMessage = "Le numéro de téléphone n'est pas valide")]
        [RegularExpression(@"^(?:(?:\+|00)33|0)*[1-9](?:[.-]*\d{2}){4}$", ErrorMessage = "Le numéro de téléphone n'est pas valide")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Le Password est requis")]
        public string Password { get; set; } = null!;

        [StringLength(8, ErrorMessage ="Le nom d'appartement est trop long")]
        public string? Apt { get; set; }
        public int? Number { get; set; }

        [Required(ErrorMessage = "La rue est requise")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "La ville est requise")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Le ZipCode est requis")]
        public string ZipCode { get; set; } = null!;

        [Required(ErrorMessage = "Le pays est requis")]
        public string Country { get; set; } = null!;
        

    }
}
