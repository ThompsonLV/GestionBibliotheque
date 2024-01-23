namespace GestionBibliotheque.Entities
{
    public class Lector: Person
    {
        public string Password { get; set; } = null!;

        public Address Address { get; set; } = null!;

        readonly List<Rentail> _rentails = new List<Rentail>();
        public IReadOnlyCollection<Rentail> Rentails => _rentails.AsReadOnly();
    }
}
