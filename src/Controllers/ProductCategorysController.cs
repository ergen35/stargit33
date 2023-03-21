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
    public class ProductCategorysController : ControllerBase
    {       
        private readonly AppDbContext _context;
        public ProductCategorysController(AppDbContext context)
        {
            _context = context;
        }

        //GET : api/v1/ProductCategorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategorys()
        {
            return await _context.ProductCategorys.ToListAsync();
        }

        //GET : api/v1/ProductCategorys/id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductCategory>>> GetProductCategory(int id)
        {
            var ProductCategory = await _context.ProductCategorys
                .Where(c => c.Id == id)
                .Include(c => c.Product)
                .ToListAsync();

            if (ProductCategory is null)
            {
                return NotFound();
            }
            return ProductCategory;
        }

        //POST : api/v1/ProductCategorys
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory ProductCategory)
        {
            _context.ProductCategorys.Add(ProductCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductCategory), new {id = ProductCategory.Id }, ProductCategory);
        }

        //PUT : api/v1/ProductCategorys
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategory ProductCategory)
        {
            if (id != ProductCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(ProductCategory).State = EntityState.Modified;

            if (_context.ProductCategorys.Any(e => e.Id == id))
            {
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetProductCategory), new {id = ProductCategory.Id}, ProductCategory);
        }


        //Delete : api/v1/ProductCategorys
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var ProductCategory = await _context.ProductCategorys.FindAsync(id);

            if (ProductCategory is null)
            {
                return NotFound();
            }

            _context.ProductCategorys.Remove(ProductCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}