

namespace Shop.web.Data
{
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entity;
    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.context.Productos.OrderBy(p => p.Nombre);
        }

        public Product GetProduct(int id)
        {
            return this.context.Productos.Find(id);
        }

        public void AddProduct(Product product)
        {
            this.context.Productos.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            this.context.Update(product);
        }

        public void RemoveProduct(Product product)
        {
            this.context.Productos.Remove(product);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool ProductExists(int id)
        {
            return this.context.Productos.Any(p => p.Id == id);
        }


    }
}
