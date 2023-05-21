using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OWT6BA_HFT_2022232.Logic.Classes;
using OWT6BA_HFT_2022232.Logic.Interfaces;
using OWT6BA_HFT_2022232.Models;
using OWT6BA_HFT_2022232.Repository.Database;
using OWT6BA_HFT_2022232.Repository.Interface;
using OWT6BA_HFT_2022232.Repository.ModelRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Endpoint
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
            // IoC container setup 
            services.AddTransient<BookDbContext>();

            services.AddTransient<IRepository<Author>,AuthorRepository>(); 
            services.AddTransient<IRepository<Book>,BookRepository>();
            services.AddTransient<IRepository<Category>, CategoryRepository>();

            services.AddTransient<IAuthorLogic, AuthorLogic>();
            services.AddTransient<IBookLogic, BookLogic>();
            services.AddTransient<ICategoryLogic, CategoryLogic>(); 


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OWT6BA_HFT_2022232.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OWT6BA_HFT_2022232.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                var response = new { Message = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
