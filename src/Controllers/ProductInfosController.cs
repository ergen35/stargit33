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
    public class ProductInfosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductInfosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInfo>>> GetProducts()
        {
            return await _context.ProductInfos.ToListAsync();
        }   

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInfo>> GetProduct(int id)
        {
            var ProductInfo = await _context.ProductInfos.FindAsync(id);
            if (ProductInfo is null)
            {
                return NotFound();
            }

            return ProductInfo;
        }

        [HttpPost]
        public async Task<ActionResult<ProductInfo>> PostProductInfo(ProductInfo ProductInfo)
        {
            _context.ProductInfos.Add(ProductInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new {id = ProductInfo.ProductID}, ProductInfo); 
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductInfo(int id, ProductInfo ProductInfo)
        {
            if (id != ProductInfo.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(ProductInfo).State = EntityState.Modified;

            if (_context.ProductInfos.Any(e => e.ProductID == id))
            {
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetProduct), new {id = ProductInfo.ProductID}, ProductInfo);
        }

        public async Task<IActionResult> DeleteProductInfo(int id)
        {
            var ProductInfo = await _context.ProductInfos.FindAsync(id);

            if (ProductInfo is null)
            {
                return NotFound();                
            }

            _context.ProductInfos.Remove(ProductInfo);
            await _context.SaveChangesAsync();

            return NoContent();

        }
        
    }
}