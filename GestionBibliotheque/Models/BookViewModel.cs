using System.ComponentModel.DataAnnotations;

namespace GestionBibliotheque.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Le titre est requis")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage ="La description est requise")]
        [MaxLength(255, ErrorMessage ="La description est trop longue")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Le nombre de page est requis")]
        public int Nbpages { get; set; }

        public Author Author { get; set; } = null!;
        public Domain Domain { get; set; } = null!;
    }
}
