using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.Repositories;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Formatters;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace JourneyChurch.Groups.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv) {
            // Setup configuration sources.

            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc(options => {
                options.OutputFormatters
                .OfType<JsonOutputFormatter>()
                .First()
                .SerializerSettings
                .ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IMeetingRepository, MeetingRepository>();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DB>(o => o.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<JourneyUser, IdentityRole>(o => {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireNonLetterOrDigit = false;
                o.Password.RequireUppercase = false;
                o.Password.RequiredLength = 3;
                }).AddEntityFrameworkStores<DB>()
                .AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            //app.UseWelcomePage();
            app.UseIdentity();
            
        }
    }
}
