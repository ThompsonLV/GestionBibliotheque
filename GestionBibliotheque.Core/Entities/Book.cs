namespace GestionBibliotheque.Entities
{
    public class Book: Entity
    {
        public string Title { get; set; } = null!;
        public int Nbpages { get; set; }

        public Author Author { get; set; } = null!;
        public Domain Domain { get; set; } = null!;
        readonly List<Rentail> _rentails = new List<Rentail>();
        public IReadOnlyCollection<Rentail> Rentails => _rentails.AsReadOnly();

    }
}
