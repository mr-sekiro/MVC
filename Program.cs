using Microsoft.AspNetCore.Hosting;

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

            app.MapGet("/", () => "Hello Abdullah!");
            app.MapGet("/Test", () => "Testing ........!");

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
