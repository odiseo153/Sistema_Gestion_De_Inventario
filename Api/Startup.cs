using Application.Alertas.Created;
using Application.Alertas.Deleted;
using Application.Alertas.GetAllAlertas;
using Application.Alertas.Update;
using Application.Chaching_;
using Application.Historial.GetAllHistorial;
using Application.Productos.Created;
using Application.Productos.Deleted;
using Application.Productos.Get;
using Application.Productos.GetById;
using Application.Productos.Update;
using Core.Entities;
using Core.Repositories;
using Infraestructure.Chaching;
using Infraestructure.Context;
using Infraestructure.Repositorie;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Api
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

            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<SistemaGestionContext>();
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());


               } );

            // Productos
            services.AddScoped<IProductRepository, ProductoRepositorie>();
            services.AddScoped<IAlertaRepository,AlertaRepositorie>();
            services.AddScoped<IUsuarioRepository, UsuarioRepositorie>();
            services.AddScoped<IHistorialInventarioRepository, HistorialInventarioRepositorie>();


            services.AddMemoryCache();
            services.AddDistributedMemoryCache();



            services.AddScoped<IRequestHandler<GetAllProductsQuery, IActionResult>, GetAllProductosHandler>();
            services.AddScoped<IRequestHandler<CreateProductCommand, Producto>, CreateProductoHandler>();
            services.AddScoped<IRequestHandler<DeletedProductoCommand, IActionResult>, DeletedProductoHandler>();
            services.AddScoped<IRequestHandler<GetProductByIdQuery, Producto>, GetProductByIdHandler>();
            services.AddScoped<IRequestHandler<UpdateProductoCommand, IActionResult>, UpdateProductoHandler>();

            services.AddScoped<IRequestHandler<GetAllAlertasQuery, IActionResult>, GetAllAlertasHandler>();
            services.AddScoped<IRequestHandler<CreatedAlertaCommand, Alerta>, CreatedAlertaHandler>();
            services.AddScoped<IRequestHandler<DeleteAlertaCommand, IActionResult>, DeleteAlertaHandler>();
            services.AddScoped<IRequestHandler<UpdateAlertaCommand, Alerta>, UpdateAlertaHandler>();

            services.AddScoped<IRequestHandler<GetAllHistorialQuery, IActionResult>, GetAllHistorialHandler>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var context = new SistemaGestionContext())
            {
                //context.Database.EnsureDeleted(); // Uncomment for database deletion on startup (use with caution)
                context.Database.EnsureCreated();
            }
        }

    }
}
