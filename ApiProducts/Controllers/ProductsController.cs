using ApiProducts.Data.Repositorys;
using Microsoft.AspNetCore.Mvc;
using ApiProducts.Domain;
using Microsoft.EntityFrameworkCore;
using ApiProducts.Data.Dtos;
using AutoMapper;

namespace ApiProducts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        
        private readonly IProductsRepository _repo;
        private readonly IMapper _mapper;

        public ProductsController(IProductsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateDto productoDto)
        {
            var productoToCreate = _mapper.Map<Products>(productoDto);

            if (((int)productoToCreate.Type) < 0 || ((int)productoToCreate.Type) > 3)
            {
                return NotFound("The type is out of range");
            }

            _repo.Add(productoToCreate);
            if (await _repo.SaveAll())
                return Ok(productoToCreate);

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repo.GetProductsById(id);
            if (product == null)
            {
                return NotFound("product not found");
            }
            return Ok(product);
        }

        [HttpGet("description/{description}")]
        public IActionResult GetByDescription(string description)
        {
            var product =  _repo.GetProductsByDescrption(description);
            if (product == null )
            {
                return NotFound("product not found");
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,ProductUpdateDto productoDto)
        {
            if (id != productoDto.Id)
            {
                return BadRequest();
            }

            if (((int)productoDto.Type) < 0 || ((int)productoDto.Type) > 3)
            {
                return NotFound("The type is out of range");
            }

            var productToUpdate = await _repo.GetProductsById(productoDto.Id);

            if (productToUpdate == null)
            {
                return BadRequest();
            }
            _mapper.Map(productoDto, productToUpdate);

            if (!await _repo.SaveAll())
            {
                return NoContent();
            }
            return Ok(productToUpdate);
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            var product =await _repo.GetProductsById(id);

            if (product == null)
            {
                return BadRequest();
            }
            _repo.Delete(product);

            if (!await _repo.SaveAll())
            {
                return NoContent();
            }
            return Ok("removed product");

        }
    }
}
