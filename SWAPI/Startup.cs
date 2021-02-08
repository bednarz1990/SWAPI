using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SWAPI.Data;
using SWAPI.Services;
using SWAPI.Services.Interfaces;

namespace SWAPI
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddTransient<ISwapiService, SwapiService>();
            services.AddScoped<ISwapiRepository, SwapiRepository>();
            services.AddControllersWithViews();

            services.AddHttpClient<IHttpHandler, HttpClientHandler>();
            services.AddDbContext<SwapiContext>(cfg => { cfg.UseSqlServer(conString); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Default",
                    "{controller}/{action}/{id?}",
                    new {controller = "Home", Action = "Films"});
            });
        }
    }
}