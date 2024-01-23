namespace GestionBibliotheque.Entities
{
    public abstract class Person: Entity
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

    }
}