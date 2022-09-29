namespace TPI_Programación3.Entities
{
    public class Offer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public string ImgLink { get; set; }
        public string CreatorEmail { get; set; }
        public string? PreferedItem {get; set; }
    }
}
