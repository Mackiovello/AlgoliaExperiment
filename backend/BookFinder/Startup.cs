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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BookFinder.Elastic;
using HotChocolate;
using HotChocolate.AspNetCore;
using BookFinder.Models;
using GraphiQl;

namespace BookFinder
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDataLoaderRegistry()
                .AddGraphQL(sp =>
            {
                return SchemaBuilder.New()
                    .AddQueryType<QueryType>()
                    .AddMutationType<MutationType>()
                    .Create();
            });


            services.AddTransient<AdlibrisScraper>();
            services.AddData(Configuration.GetSection("Elastic").Get<ElasticSettings>());
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseGraphQLHttpPost(new HttpPostMiddlewareOptions { Path = "/graphql" })
                .UseGraphQLHttpGetSchema(new HttpGetSchemaMiddlewareOptions { Path = "/graphql/schema" });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphiQl();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
