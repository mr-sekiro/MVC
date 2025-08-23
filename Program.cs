using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Text;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region ConfigureServices

            builder.Services.AddControllersWithViews();

            #endregion

            var app = builder.Build();

            #region Configure

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            //The process of mapping incoming HTTP requests to specific controlleractions or endpoints
            //  Conventional Routing => You define a general pattern for routes.
            //  Attribute Routing => You decorate controllers/actions with [Route] attributes, More control over URL structure.

            //HTTP://BaseURL/SEGMENT/{SEGMENT}/X{SEGMENT}
            //               static  varible   mixed

            //app.MapGet("/", () => "Hello Abdullah!");
            //app.MapGet("/Test", () => "Testing ........!");

            //app.MapGet("/{name}", async context =>
            //{
            //    var Name = context.GetRouteValue("name");
            //    await context.Response.WriteAsync($"Hello {Name}");
            //    //await context.Response.WriteAsync($"Hello {context.Request.RouteValues["name"]}");
            //});

            //// Conventional Routing
            app.MapControllerRoute(
                "Default",
                "{controller}/{action}/{id?}",//id is Optional
                new { controller = "Home", action = "Index" }
                //new { Id = new IntRouteConstraint() }
                );

            //app.MapControllerRoute(
            //    "Default",
            //  "{controller}/{action=Index}/{id:regex(\\d{{2}}$)?}");

            app.MapControllers();   // For [Route] attributes
            #endregion

            app.Run();
        }
    }

    ////.NET 5 style(Startup + Program.cs)

    //public class Startup
    //{
    //    public IConfiguration Configuration { get; }

    //    public Startup(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    // Called by the runtime
    //    // Configure services (DI container)
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        //services.AddMvc(); // add Controllers, Viwes, Razor pages, API
    //        //services.AddMvcCore(); // add Controllers (Minimal)
    //        //services.AddRazorPages(); // add Views, Razor Pages
    //        //services.AddControllers(); // Support API Controllers
    //        services.AddControllersWithViews(); // add  Controllers, Viwes, support API Controllers
    //    }

    //    // Called by the runtime
    //    // Configure HTTP request pipeline
    //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage(); //MiddleWare For Errors
    //        }

    //        app.UseRouting(); //MiddleWare For Routing

    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapGet("/", async context =>
    //            await context.Response.WriteAsync("Hello Abdullah"));
    //        }); //MiddleWare For Endpoints Route Mapping
    //    }
    //}

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        CreateHostBuilder(args).Build().Run();
    //    }

    //    public static IHostBuilder CreateHostBuilder(string[] args) =>
    //        Host.CreateDefaultBuilder(args)
    //            .ConfigureWebHostDefaults(webBuilder =>
    //            {
    //                webBuilder.UseStartup<Startup>();
    //            });
    //}
}
