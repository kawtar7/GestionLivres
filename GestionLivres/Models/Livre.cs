namespace GestionLivres.Models
{
    public class Livre
    {
        public int ISBN { get; set; }
        public String Titre { get; set; }
        public String Auteur { get; set; }
        public DateOnly DateEdition { get; set; } 
        public string Resume { get; set; }
    }
}
