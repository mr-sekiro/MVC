using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Actions
// Is a method must meet certain requirements
//  The method must be public.
//  The method cannot be a static method.
//  The method cannot be an extension method.
//  The method cannot be a constructor, getter, or setter.
//  The method cannot have open generic types.
//  The method is not a method of the controller base class.
//  The method cannot contain ref or out parameters.

//Types of action results:
//  ViewResult - Represents HTML and markup.
//  EmptyResult - Represents no result.
//  RedirectResult - Represents a redirection to a new URL.
//  JsonResult - Represents a JavaScript Object Notation result that can be used in an AJAX application.
//  JavaScriptResult - Represents a JavaScript script.
//  ContentResult - Represents a text result.
//  FileContentResult - Represents a downloadable file (with the binary content).
//  FilePathResult - Represents a downloadable file (with a path).
//  FileStreamResult - Represents a downloadable file (with a file stream)

//all public methods in a Controller are treated as action methods(meaning they can be reached via a URL).
//If you have a helper method inside a controller, you don’t want ASP.NET Core to expose it as an endpoint.
//That’s where [NonAction] comes in.

//Model Binding [Action Parameters]
//Is the Process of automatically mapping incoming HTTP request data to action method parameters or model properties

//Value Providers[In Order]
//	- Form
//	- Route Data
//	- Query String
//	- Request Body
//	- Request Header

//Model Data Can Be 
// Simple Data => Name
// Complex Data => Object.Attribute, Attributes
// Mixed Data => Any Match
// Collection => Name Accumulatively, [index]
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

        #region Example 1
        //[Route("GetProduct/{id:int?}")]
        //// baseUrl/Products/GetProduct/10
        //public ContentResult GetProduct(int? id, string name)
        //{
        //    //ContentResult result = new ContentResult();
        //    //result.Content = $"Product id: {id}<br>Product Name: {name}";
        //    //result.ContentType = "text/html";
        //    //return result;

        //    return Content($"Product id: {id}<br>Product Name: {name}", "text/html");
        //} 
        #endregion

        #region Example 2
        [Route("GetProduct/{id:int?}")]
        // baseUrl/Products/GetProduct/10
        public IActionResult GetProduct(int? id, string name)
        {

            if (id == 0)
            {
                return BadRequest();
            }
            else if (id < 10)
            {
                return NotFound();
            }
            else
                return Content($"Product id: {id}<br>Product Name: {name}", "text/html");

        }
        #endregion
        [Route("TestRedirect")]
        public IActionResult TestRedirect()
        {
            return RedirectToRoute("Defult", new { controller = "Products", action = "GetProduct", id = 10 });
            //return RedirectToAction(nameof(GetProduct),"Products", new { id = 10 });
            //return Redirect("https://localhost:44387/Products/GetProduct/10");
            //return Redirect("https://www.apple.com/eg/iphone-16-pro/");
        }

        [HttpPost]
        [Route("TestModelBinding")]
        public IActionResult TestModelBinding([FromQuery] int id, [FromQuery] string name)
        {
            return Content($"Product id: {id}<br>Product Name: {name}", "text/html");
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct([FromBody] Product product) // [FromHeader] is not workink with complex data
        {
            if (product == null)
                return BadRequest();
            else
                return Content($"Product id: {product.Id}<br>Product Name: {product.Name}", "text/html");
        }

        [NonAction]
        public void Test()
        {

        }
    }
}
