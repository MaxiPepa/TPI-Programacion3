namespace TPI_Programación3.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public List<Offer>? Offers { get; set; }

        public Category(string name, List<Offer>? offers)
        {
            Name = name;
            Offers = offers;
        }
    }
}