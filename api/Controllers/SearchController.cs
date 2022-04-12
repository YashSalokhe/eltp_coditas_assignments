using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IService<Product, int> proServ;
        private readonly IService<Category, int> catServ;

        public SearchController(IService<Product, int> proServ, IService<Category, int> catServ)
        {
            this.proServ = proServ;
            this.catServ = catServ;
        }
        // [HttpGet]
        [HttpGet("{name}")]

        public IActionResult Get(string name)
        {
            //List<Product> pro = new List<Product>();
            if (ModelState.IsValid)
            {
                var cat = catServ.GetAsync().Result.Where(x => x.CategoryName == name).Select(x => x.CategoryRowId).FirstOrDefault();
                var pro = proServ.GetAsync().Result.Where(x => x.CategoryRowId == cat);
              //  var t = JsonSerializer.Serialize(pro);
                return Ok(pro);
            }
            return BadRequest();
        }
    }
}
