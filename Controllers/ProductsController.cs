using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using static System.Collections.Specialized.BitVector32;

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
        [NonAction]
        public void Test()
        {

        }
    }
}
