namespace GestionBibliotheque.Entities
{
    public abstract class Person: Entity
    {
        public string Name { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

    }
}