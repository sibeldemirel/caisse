namespace caisse.Models
{
    public class CategorieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProduitModel> produits { get; set; }

    }
}
