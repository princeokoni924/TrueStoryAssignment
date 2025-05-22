using BLLInfrastructure.ProductRepository;
using DALCore.IRepository;
using DALCore.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace MockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductRepository _productRepo): ControllerBase
    {
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProduct([FromQuery] string? name, int page = 1, int size = 10)
        {
            var result = await _productRepo.GetAllProductAsync(name, page, size);
            return Ok(result);
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] AddProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
                var add = await _productRepo.CreatProductAsync(dto);
            
            return CreatedAtAction(nameof(GetAllProduct), new { add.Id}, add);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            var delete = await _productRepo.DeleteProduct(id);
            if (!delete)
            {
                return Ok(delete);
            }
            else
            {
                return NotFound("not data to delete");
            }
            
        }
    }
}
