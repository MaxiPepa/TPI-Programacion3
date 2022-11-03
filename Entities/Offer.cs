using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPI_Programación3.Entities
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImgLink { get; set; }
        public string CreatorEmail { get; set; }
        public string? PreferedItem {get; set; }

        public Offer(int id, string name, string description, string category, string imgLink, string creatorEmail, string? preferedItem)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            ImgLink = imgLink;
            CreatorEmail = creatorEmail;
            PreferedItem = preferedItem;
        }
    }
}