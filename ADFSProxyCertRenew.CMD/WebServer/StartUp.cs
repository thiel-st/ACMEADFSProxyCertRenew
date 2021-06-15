using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADFSProxyCertRenew.WebServer
{
    class StartUp : IStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(config =>
            {

            });

            return services.BuildServiceProvider();
        }
    }
}
