using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product,int> proServ;
        public ProductController(IService<Product, int> proServ)
        {
            this.proServ = proServ;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var res = proServ.GetAsync().Result;
            // JSON Serialize the Resonse
            return Ok(res);
        }
  
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = proServ.GetAsync(id).Result;
            // JSON Serialize the Resonse
            return Ok(res);
        }
  
        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                var res = proServ.CreateAsync(product).Result;
                return Ok(res);
            }
            else
            {
                // Data is Invalid
                return BadRequest(ModelState);
            }
        }
   
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            
            var record = proServ.GetAsync(id).Result;
            if (record == null) return NotFound($"BAsed of Category Row Id {id} the record is not found");

            
            if (id != product.CategoryRowId)
                return BadRequest($"Id for seaarch {id} does not match with Category Row Id in Body {product.CategoryRowId}");

            if (ModelState.IsValid)
            {
                var res = proServ.UpdateAsync(id, product).Result;
                return Ok(res);
            }
            else
            {
                
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = proServ.DeleteAsync(id).Result;
            return Ok(res);
        }

    }
}
