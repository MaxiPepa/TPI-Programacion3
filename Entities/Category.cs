using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPI_Programación3.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int OfferQuantity { get; set; }

        public Category(int id, string name, int offerQuantity)
        {
            Id = id;
            Name = name;
            OfferQuantity = offerQuantity;
        }
    }
}