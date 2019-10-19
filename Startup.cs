using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDSTecnologia.FaceAlbum.Web.Data;

namespace TDSTecnologia.FaceAlbum.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFrameworkNpgsql()
            .AddDbContext<AppContexto>(options => options.UseNpgsql(Configuration.GetConnectionString("AppConnection")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            //app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseMvc(options => {
                options.MapRoute(name: "default", template: "{controller=Album}/{action=Index}/{id?}");
            });
        }
    }
}
