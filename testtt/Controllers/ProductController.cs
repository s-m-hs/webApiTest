using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using testtt.Context;
using Models;
using DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace testtt.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class ProductController: ControllerBase
    {
        public TestContext _db { get; set; }
        private readonly IMapper _mapper;

        public ProductController(TestContext testContext, IMapper mapper)
        {
            _db = testContext;
            _mapper = mapper;
           
        }

        [HttpPost("addProduct")]
        public async Task<ActionResult> addProduct(ProductDTO product)
        {
            if (product == null) { return BadRequest(); }
            //var newProduct=await _db.Products.AddAsync(product);
            var newProduct = _mapper.Map<Product>(product);
            newProduct.IsVisible = true;
            newProduct.CreateDate = DateTime.Now;
            var result = await _db.Products.AddAsync(newProduct);
            await _db.SaveChangesAsync();
            return Ok( result.Entity);
        }

        [HttpGet("getAllProduct")]
        public async Task<ActionResult<List<ProductDTO>>> getAllProduct()
        {

            var productArray = await _db.Products.ToArrayAsync();
            var productArrayB = _mapper.Map<List<ProductDTO>>(productArray);
            if (!productArrayB.Any()) return NotFound();
            return Ok(productArrayB);
        }

    
    }
}
