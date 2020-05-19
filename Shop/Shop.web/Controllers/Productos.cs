using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.web.Data;
using Shop.web.Data.Entity;

namespace Shop.web.Controllers
{
    public class Productos : Controller
    {
        private readonly IRepository repository;

        public Productos(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Productos
        public IActionResult Index()
        {
            return View(this.repository.GetProducts());
        }

        // GET: Productos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.repository.GetProduct(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Product product)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddProduct(product);
                await this.repository.SaveAllAsync();
                //devuelve verdadero y falso
             
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Productos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

         
            var product = this.repository.GetProduct(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Productos/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdateProduct(product);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Productos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.repository.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = this.repository.GetProduct(id);
            this.repository.RemoveProduct(product);
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
