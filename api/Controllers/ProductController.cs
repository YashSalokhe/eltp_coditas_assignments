using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {                                                  
        private readonly IService<Product,int> proServ;
        private readonly IService<Category, int> catServ;
        public ProductController(IService<Product, int> proServ, IService<Category, int> catServ)
        {
            this.proServ = proServ;
            this.catServ = catServ;
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
            int BasePrice =catServ.GetAsync().Result.Where(x => x.CategoryRowId == product.CategoryRowId).Select(x => x.BasePrice).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (BasePrice <= product.price)
                {
                    var res = proServ.CreateAsync(product).Result;
                    return Ok(res);
                }
                else
                {
                    return BadRequest("Base Price Must Greater Than or Is equal to Product Price");

                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
   
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            
            var record = proServ.GetAsync(id).Result;
            if (record == null) return NotFound($"BAsed of Category Row Id {id} the record is not found");

            
            if (id != product.ProductRowId)
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
