namespace Salon_de_infrumusetare.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public ICollection<serviciu> Servicii { get; set; }
    }
}
