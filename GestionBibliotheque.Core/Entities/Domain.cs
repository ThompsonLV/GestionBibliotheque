namespace GestionBibliotheque.Entities
{
    public class Domain: Entity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        readonly List<Book> _books = new List<Book>();
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

    }
}
