namespace Salon_de_infrumusetare.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ServiciuCategory> ServiciuCategories { get; set; }

    }
}
