namespace Salon_de_infrumusetare.Models
{
    public class ServiciuCategory
    {
        public int ID { get; set; }
        public int ServiciuID { get; set; }
        public serviciu Serviciu { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
