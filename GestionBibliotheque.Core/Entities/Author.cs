namespace GestionBibliotheque.Entities
{
    public class Author: Person
    {
        public string Grade { get; set; } = null!;

        readonly List<Book> _books = new List<Book>();
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();
    }
}
