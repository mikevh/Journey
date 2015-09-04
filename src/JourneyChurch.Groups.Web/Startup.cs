using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Repositories;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace JourneyChurch.Groups.Web
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddSingleton<ITodoRepository, TodoRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.UseWelcomePage();
        }
    }
}
