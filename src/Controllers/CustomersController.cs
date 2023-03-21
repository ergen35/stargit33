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
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/v1/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        //GET: api/v1/Customers/id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Customer>>> GetCustomer(long id)
        {
            var Customer = await _context.Customers
                .Where(c => c.Id == id)
                .Include(c => c.Products)
                .ToListAsync();

            if (Customer  is null)
            {
                return NotFound();              
            }
            return Customer;
        }

        //POST : api/v1/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer Customer)
        {
             _context.Customers.Add(Customer);
              await _context.SaveChangesAsync();

              return CreatedAtAction(nameof(GetCustomer), new {id = Customer.Id}, Customer);

        }

        //PUT : api/v1/Customers/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer Customer)
        {
            if (id != Customer.Id)
            {
                return BadRequest();                
            }            

            _context.Entry(Customer).State = EntityState.Modified;

            if (_context.Customers.Any(e => e.Id == id))
            {   
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

           return CreatedAtAction(nameof(GetCustomer), new {id = Customer.Id}, Customer);
            
        }

        
        // Delete: api/v1/Customers/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var Customer = await _context.Customers.FindAsync(id);
            if (Customer is null)
            {
                return NotFound();
            }

            _context.Customers.Remove(Customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}