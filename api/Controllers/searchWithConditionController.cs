using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class searchWithCondition : ControllerBase
    {
        private readonly IService<Category, int> catServ;
        private readonly IService<Product, int> productServ;
        public searchWithCondition(IService<Category, int> catServ, IService<Product, int> productServ)
        {
            this.catServ = catServ;
            this.productServ = productServ;
        }
        [HttpGet("{Operator}")]
        public IActionResult Search(string? CategoryNAme, string? ProductName, string Operator)
        {
            if (ModelState.IsValid)
            {
                if (Operator.ToUpper() == "AND")
                {
                    if (CategoryNAme != null && ProductName != null)
                    {
                        var catID = catServ.GetAsync().Result.Where(x => x.CategoryName == CategoryNAme).Select(x => x.CategoryRowId).FirstOrDefault();
                        if (catID != 0)
                        {
                            var catResultant = catServ.GetAsync(catID).Result;
                            var proExistance = productServ.GetAsync().Result.Where(x => x.CategoryRowId == catID);
                            if (proExistance != null)
                            {
                                var product = proExistance.Where(x => x.ProductName.ToLower() == ProductName.ToLower());
                                CatProd categoryProduct = new CatProd();

                                categoryProduct.category.CategoryRowId = catID;
                                categoryProduct.category.CategoryName = catResultant.CategoryName;
                                categoryProduct.category.BasePrice = catResultant.BasePrice;

                                categoryProduct.Products = new List<Product>();
                                foreach (Product p in product)
                                {
                                    categoryProduct.Products.Add(new Product() { CategoryRowId = p.CategoryRowId, ProductName = p.ProductName, ProductId = p.ProductId });
                                }
                                return Ok(categoryProduct);
                            }
                            else
                            {
                                return BadRequest("No Such Product Found Under Specified Category!You Can Search With Or Condition");
                            }
                        }
                        else
                        {
                            return BadRequest("Oh Oh!No Such Catagory!");
                        }
                    }
                    return BadRequest("Specify Both The Fields If You Want To Search With And COndition");
                }
                else if (Operator.ToUpper() == "OR")
                {
                    if (CategoryNAme != null && ProductName != null)
                    {
                        var catID = catServ.GetAsync().Result.Where(x => x.CategoryName == CategoryNAme).Select(x => x.CategoryRowId).FirstOrDefault();
                        //var proExist = productServ.GetAsync().Result.Where(x => x.CategoryRowId == catID);
                        //var prod = proExist.Where(x => x.ProductName.ToLower() == ProductName.ToLower());
                        if (catID != 0)
                        {
                            var catRes = catServ.GetAsync(catID).Result;
                            var proExistance = productServ.GetAsync().Result.Where(x => x.CategoryRowId == catID);
                            if (proExistance != null)
                            {
                                var product = proExistance.Where(x => x.ProductName.ToLower() == ProductName.ToLower());
                                Category cat = new Category()
                                {
                                    CategoryRowId = catID,
                                    CategoryName = catRes.CategoryName,
                                    BasePrice = catRes.BasePrice
                                };


                                CatProd categoryProduct = new CatProd()
                                {
                                    category = cat
                                };
                                categoryProduct.Products = new List<Product>();
                                foreach (Product p in product)
                                {
                                    categoryProduct.Products.Add(new Product() { CategoryRowId = p.CategoryRowId, ProductName = p.ProductName, ProductId = p.ProductId });
                                }
                                return Ok(categoryProduct);
                            }
                            else
                            {
                                return Ok(catRes);
                            }
                        }
                        else
                        {
                            var prod = productServ.GetAsync().Result.Where(x => x.ProductName.ToLower() == ProductName.ToLower());
                            if (prod.Count() != 0)
                            {
                                return Ok(prod);
                            }
                            else
                            {
                                return BadRequest("No Such Category, No Such Product Exists");
                            }
                        }
                    }
                    else if (CategoryNAme != null)
                    {
                        var catID = catServ.GetAsync().Result.Where(x => x.CategoryName == CategoryNAme).Select(x => x.CategoryRowId).FirstOrDefault();
                        if (catID != 0)
                        {
                            var catRes = catServ.GetAsync(catID).Result;
                            return Ok(catRes);
                        }
                        else
                        {
                            return BadRequest("No Such Category Exists");
                        }
                    }
                    else if (ProductName != null)
                    {
                        var prod = productServ.GetAsync().Result.Where(x => x.ProductName.ToLower() == ProductName.ToLower());
                        if (prod.Count() != 0)
                        {
                            return Ok(prod);
                        }
                        else
                        {
                            return BadRequest("No Such Product Exists");
                        }
                    }
                }
                else
                {
                    return BadRequest("Oh Oh!Invalid Operator!");
                }
            }
            return BadRequest("Oh Oh!Nothing Found!!!");
        }
    }
}






















