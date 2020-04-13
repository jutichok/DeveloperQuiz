using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperQuiz.Persistances.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DeveloperQuiz.Domains.Services;
using DeveloperQuiz.Services;
using DeveloperQuiz.Repositories;
using DeveloperQuiz.Domains.Repositories;
using DeveloperQuiz.Domains.Models;

namespace DeveloperQuiz
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
            services.AddControllers();

            services.AddDbContext<MemoryDBContext>(opt => opt.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            services.AddScoped<MemoryDBContext>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();


            services.AddAutoMapper(typeof(Startup));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        
    }
}
