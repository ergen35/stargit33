using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPIS.Models;
using MinimalAPIS.Data;

namespace MinimalAPIS.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        //Get : api/v1/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        //Get : api/v1/Products
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProduct(int id)
        {
           var Product = await _context.Products    
                .Where(c => c.CustomerId == id)
                .Include(c => c.ProductCategory)
                .Include(c => c.ProductInfo)
                .ToListAsync();

           if (Product is null)
           {
                return NotFound();
           }

           return Product;
             
        }

        //POST: api/v1/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product Product) 
        {
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new {id = Product.Id}, Product);
        }
        
        //PUT: api/v1/Products
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product Product)
        {
            if (id != Product.Id)
            {
                return BadRequest();
            }

            _context.Entry(Product).State = EntityState.Modified;

            if (_context.Products.Any(e => e.Id == id))
            {
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetProduct), new {id = Product.Id}, Product);
        }

        //Delete : api/v1/Products
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var Product = await _context.Products.FindAsync(id);

            if (Product is null)
            {
                return NotFound();
            }

            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}