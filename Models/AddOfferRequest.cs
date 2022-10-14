namespace TPI_Programación3.Models
{
    public class AddOfferRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImgLink { get; set; }
        public string CreatorEmail { get; set; }
        public string? PreferedItem { get; set; }
    }
}
