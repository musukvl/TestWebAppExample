using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ExampleWebApi
{
    public partial class Startup
    {
        private static void ConfigureOpenApiServices(IServiceCollection services)
        {

            services.AddOpenApiDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Title = "Search Application API";
                };
            });
        }

        private static void ConfigureSwagger(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
