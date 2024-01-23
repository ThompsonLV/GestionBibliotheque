using System.ComponentModel.DataAnnotations;

namespace GestionBibliotheque.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Le nom est requis")]
        [StringLength(30, ErrorMessage ="Le nom est trop long")]
        public string Firstname { get; set; } = null!;

        [Required(ErrorMessage = "Le prénom est requis")]
        [StringLength(30, ErrorMessage ="Le prénom est trop long")]
        public string Lastname { get; set; } = null!;

        [Required(ErrorMessage = "Le mail est requis")]
        [EmailAddress(ErrorMessage = "Le mail n'est pas valide")]
        public string Email { get; set; } = null!;

        [StringLength(10, ErrorMessage ="Le numéro de téléphone n'est pas valide")]
        [RegularExpression(@"^(?:(?:\+|00)33|0)*[1-9](?:[.-]*\d{2}){4}$", ErrorMessage ="Le numéro de téléphone n'est pas valide")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage ="Le grade est requis")]
        public string Grade { get; set; } = null!;
    }
}
