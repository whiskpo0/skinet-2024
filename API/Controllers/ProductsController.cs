using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly IProductRepository _repo; 
        public ProductsController(StoreContext context, IProductRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        { 
            var products = await _repo.GetProductsAsync(); 
            
            return Ok(products); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        { 
            return await _repo.GetProductById(id); 
        }        
    }
}