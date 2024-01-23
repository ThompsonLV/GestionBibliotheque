using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GestionBibliotheque.Models
{
    public class DomainViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(50, ErrorMessage ="Le nom est trop long")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "La description est requise")]
        [StringLength(255, ErrorMessage = "La description est trop long")]
        public string Description { get; set; } = null!;

        //readonly List<Book> _books = new List<Book>();
    }
}
