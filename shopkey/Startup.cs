using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;

using shopkey.Models;
using shopkey.Controllers;

namespace shopkey
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
            services.AddControllersWithViews();
            ConfigureAuthenticationServices(services);

            services.AddCors();

            services
            .AddDbContext<ShopkeyContext>()


            .AddDataLoaderRegistry()
            .AddInMemorySubscriptions()
             .AddGraphQL(sp =>
                  SchemaBuilder.New()
                      .AddServices(sp)

                      .AddQueryType(d => d.Name("Query"))
                      .AddType<Itemgroups>()


                        .AddMutationType(d => d.Name("Mutation"))
                      .AddType<Items>()

                       .AddAuthorizeDirectiveType()
                      .BindClrType<string, StringType>()
                      .BindClrType<Guid, IdType>()
                      .Create(),
                      new QueryExecutionOptions { ForceSerialExecution = true }
                      );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors(o => o
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin());

            app.UseRouting();

            app.UseAuthentication();

            app.UseWebSockets();

            app.UseGraphQL()
                .UsePlayground()
                .UseVoyager();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            app.UseAuthentication();
        }
        private void ConfigureAuthenticationServices(IServiceCollection services)
        {

        }
    }
}
