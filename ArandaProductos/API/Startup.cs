using Application.Interface;
using Application.Main;
using Domain.Core;
using Domain.Entity;
using Domain.Interface;
using Infrastructure.Data;
using Infrastructure.Data.Helpers;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Transversal.Common.Mapper;

namespace API
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

            services.AddControllers()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Productos Aranda", Version = "v1" });
            });
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            services.AddScoped<IProductosApplication, ProductosApplication>();
            services.AddScoped<IProductosDomain, ProductosDomain>();
            services.AddScoped<IProductosRepository, ProductosRepository>();

            services.AddScoped<ICategoriasApplication, CategoriasApplication>();
            services.AddScoped<ICategoriasDomain, CategoriasDomain>();
            services.AddScoped<ICategoriasRepository, CategoriasRepository>();

            services.AddScoped<ISortHelper<Categorias>, SortHelper<Categorias>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
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
