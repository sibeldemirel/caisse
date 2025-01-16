namespace caisse.Models
{
    public class Produit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int InStockQtte { get; set; }
        public string Cetgory { get; set; }
        public string Image { get; set; }
        
    }
}
