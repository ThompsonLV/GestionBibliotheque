namespace GestionBibliotheque.Entities
{
    public class Address: Entity
    {
        public string Apt { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Country { get; set; } = null!;

        readonly List<Lector> _lectors = new List<Lector>();
        public IReadOnlyCollection<Lector> Lectors => _lectors.AsReadOnly();
    }
}
