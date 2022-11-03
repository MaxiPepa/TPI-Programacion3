using Microsoft.EntityFrameworkCore;
using TPI_Programación3.Entities;

namespace TPI_Programación3.DBContext
{
    public class TridentExchangeDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public TridentExchangeDBContext(DbContextOptions<TridentExchangeDBContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User(1, "Alejo", "alejo@gmail.com", "123", "Common"),
                new User(2, "Gaston", "gaston_elcapo@gmail.com", "abc", "Common"),
                new User(3, "Maxi", "elmassi@gmail.com", "789", "Common"),
                new User(4, "Milton", "milton_tucson_tuki@gmail.com", "qwe", "Administrator"),
                new User(5, "Pedro", "pedrito@gmail.com", "cxz", "Administrator")
            );

            modelBuilder.Entity<Offer>().HasData(
                new Offer(1, "Licuadora", "Es literalmente una licuadora", "Electrodoméstico", "https://url24.top/vJGZp", "alejo@gmail.com", "Batidora"),
                new Offer(2, "Tostadora", "Sirve para tostar pan", "Electrodoméstico", "https://url24.top/AvyPV", "gaston_elcapo@gmail.com", "Tostadora"),
                new Offer(3, "Auto", "Corsita 2009", "Vehiculo", "https://url24.top/hqPKD", "elmassi@gmail.com", "Auto"),
                new Offer(4, "Casa", "Casa dos pisos", "Inmueble", "https://url24.top/lPhra", "milton_tucson_tuki@gmail.com", "Vivienda"),
                new Offer(5, "Figurita", "La figurita de Messi", "Mundial", "https://url24.top/TvJrw", "pedrito@gmail.com", "Mundial")
           );

            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Electrodomésticos", 10),
                new Category(2, "Vehiculo", 5),
                new Category(3, "Inmueble", 2),
                new Category(4, "Mundial", 20)
           );

            base.OnModelCreating(modelBuilder);
        }

    }
}
