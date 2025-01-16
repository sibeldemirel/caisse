namespace caisse.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Produit> produits { get; set; }

    }
}
