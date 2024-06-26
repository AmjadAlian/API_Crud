using API_Crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> studnets = new List<Product>{
        new Product {Id=1, Name="example1",description="example1" },
        new Product {Id=2, Name="example2",description=" example2" },
        new Product {Id=3, Name="example3",description="example3" },
        };


        [HttpGet]
        public IActionResult GetAll ()
        {
            return Ok(studnets);
        }

        [HttpGet("{id}")]
        public IActionResult GetById (int id) {
         
            var Product = studnets.FirstOrDefault(Product=>Product.Id == id);
        
            if (Product == null)
            {
                return NotFound();
            }

            return Ok(Product);
        }

        [HttpPost]

        public IActionResult Create (Product request) {
        
            if (request == null)
            {
                return BadRequest();
            }
            var Product = new Product { Id = request.Id , Name = request.Name , description=request.description };

            studnets.Add(Product);
            return Ok(Product);

        }
        [HttpPut("{id}")]

        public IActionResult Update (int id,Product request)
        {
            var currentProduct = studnets.FirstOrDefault(Product=>Product.Id == id);

            if(currentProduct == null)
            {
                return NotFound();
            }
            
            currentProduct.Name = request.Name;
            currentProduct.description = request.description;

            return Ok(currentProduct);
        }
        [HttpDelete ("{id}")]

        public IActionResult Delete (int id) {
        var Product = studnets.FirstOrDefault(Product=>Product.Id == id);
            if (Product is null)
            {
                return NotFound();
            }
            studnets.Remove(Product);
            return Ok();
        }

    } 
}
