using ESGENDPOINTS.Application.Queries;
using ESGENDPOINTS.Infrastructure.Data;
using ESGENDPOINTS.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace ProdutosApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProdutosApi", Version = "v1" });
            });

            var connectionString = Environment.GetEnvironmentVariable("CONN_STR");
            services.AddDbContext<ApiDbContext>
                (options => options.UseSqlServer(connectionString));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<ITarefasRepository, TarefasRepository>();
            services.AddTransient<ITarefasQueries, TarefasQueries>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProdutosApi v1"));

                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseExceptionHandler(options => options.Run(async context =>
            //{

            //    context.Response.ContentType = "application/json";
            //    context.Response.StatusCode = StatusCodes.Status400BadRequest;

            //    var ex = context.Features.Get<IExceptionHandlerFeature>();

            //    if (ex == null) return;

            //    if (ex.Error is ValidationException validationException)
            //    {
            //        var errors = validationException.Errors.Select(error => new { PropertyName = error.PropertyName, ErrorMessage = error.ErrorMessage });
            //        var json = JsonSerializer.Serialize(new { Message = ex.Error.Message, errors = errors });
            //        await context.Response.WriteAsync(json);
            //    }
            //    else
            //    {
            //        var errorMessage = new { Message = ex.Error.Message };
            //        var json = JsonSerializer.Serialize(errorMessage);
            //        await context.Response.WriteAsync(json);
            //    }
            //}));

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });        
        }
    }
}