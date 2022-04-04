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
using Microsoft.OpenApi.Models;
using projectServices.Context;
using projectServices.Controllers;
using projectServices.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;


namespace projectServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "projectServices", Version = "v1" });

            });



            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        // builder
                        //     .WithOrigins("localhost:3000")
                        //     .AllowAnyHeader()
                        //     .AllowAnyMethod();

                         builder
                             .AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader();

                    });
            });

            services.AddDbContext<UsersContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            services.AddDbContext<CartContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));
            services.AddDbContext<LoginContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UsersConnStr")));

            services.AddControllers();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "projectServices v1"));
            }



            // app.UseHttpsRedirection();
            app.UseMiddleware<OptionsMiddleware>();
            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}