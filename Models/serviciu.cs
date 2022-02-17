using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_de_infrumusetare.Models
{
    public class serviciu
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Tip serviciu")]

        public string Tip_serviciu { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$"), Required,
StringLength(50, MinimumLength = 3)]
        public string Personalul { get; set; }

        [Range(1, 300)]

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }    //navigation property

    public ICollection<ServiciuCategory> ServiciuCategories { get; set; }

    }

}
