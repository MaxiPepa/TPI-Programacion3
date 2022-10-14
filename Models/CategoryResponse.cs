namespace TPI_Programación3.Models
{
    public class CategoryResponse
    {
        public string Name { get; set; }
        public List<Entities.Offer>? Offers { get; set; }
    }
}
