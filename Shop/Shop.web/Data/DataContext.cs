
using Microsoft.EntityFrameworkCore;
using Shop.web.Data.Entity;

namespace Shop.web.Data
{
    public class DataContext:DbContext
    {
        //conecta el modelo product con la tabla products
        public DbSet<Product> Products { get; set; }
        //constructor a la base de datos
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
