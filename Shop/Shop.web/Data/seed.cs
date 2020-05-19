using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.web.Data.Entity;
//using Microsoft.EntityFrameworkCore;
using Shop.web.Models;

namespace Shop.web.Data.Entity
{
    public class Seed
    {
        private readonly DataContext context;
        private Random random;

        public Seed(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Productos.Any())
            {
                this.AddProduct("Leche Sula");
                this.AddProduct("Pan");
                this.AddProduct("Cafe");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this.context.Productos.Add(new Product
            {
                Nombre = name,
                Precio = this.random.Next(10),
                Disponibilidad= true,
                Stock = this.random.Next(100)
            });
        }

    }
}
