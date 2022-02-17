namespace Salon_de_infrumusetare.Models
{
    public class ServiciuData
    {
        public IEnumerable<serviciu> serviciu { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ServiciuCategory> ServiciuCategories { get; set; }
    }
}
