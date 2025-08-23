using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [Route("Products")] //Attribute Routing
    public class ProductsController : Controller
    {
        [Route("Index")]
        // baseUrl/Products/Index
        public string Index()
        {
            return "Hello From Index";
        }
        [Route("GetProduct/{id:int?}")]
        // baseUrl/Products/GetProduct/10
        public void GetProduct(int? id, string name)
        {
            Response.WriteAsync($"Product Id: {id}\nProduct Name: {name}");
        }
    }
}
