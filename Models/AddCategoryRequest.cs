namespace TPI_Programación3.Models
{
    public class AddCategoryRequest
    {
        public string Name { get; set; }
        public List<Entities.Offer>? Offers { get; set; }
    }
}
