using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatProdController : ControllerBase         
    {
        private readonly IService<Product, int> proServ;
        private readonly IService<Category, int> catServ;

        public CatProdController(IService<Product, int> proServ, IService<Category, int> catServ)
        {
            this.proServ = proServ;
            this.catServ = catServ;
        }

        [HttpPost]
        public IActionResult CatProduct( CatProd data)
        {
            
         //   var product = data.Products.ToList();

            if (ModelState.IsValid)
            {

                var res = catServ.CreateAsync(data.category).Result;

                foreach(var item in data.Products)
                {
                    item.CategoryRowId = data.category.CategoryRowId;
                    var res1 = proServ.CreateAsync(item).Result;
                }
                return Ok(data);
            }

            return BadRequest(ModelState);
        }
      
    }
}
