using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositorie
{
    public class ProductoRepositorie : IProductRepository
    {
        private SistemaGestionContext context;

        public ProductoRepositorie(SistemaGestionContext context)
        {
            this.context = context;
        }

        public async Task<Producto> CreateProduct(Producto product)
        {            
                context.Productos.Add(product);
                await context.SaveChangesAsync();

                return product;
        }

        public async Task<IActionResult> DeleteProducts(Guid id)
        {
            var producto = context.Productos.Find(id);
            try
            {
                context.Productos.Remove(producto);
                await context.SaveChangesAsync();

                return new JsonResult(new
                {
                    menssage = "Producto eliminado con exito",
                    code = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    message = "Hubo un error al eliminar el producto",
                    code = StatusCodes.Status500InternalServerError,
                    ErrorMessage = ex.Message,
                });
            }
        }

        public async Task<IActionResult> GetProducts() => new JsonResult(context.Productos.ToList());


        public Producto GetProductsById(Guid id) => context.Productos.SingleOrDefault(x => x.Id == id);

        public async Task<IActionResult> UpdateProducts(Producto product, string motivo = "no se especificó el motivo")
        {
            var producto = context.Productos.FirstOrDefault(x => x.Id.Equals(product.Id));

            if (producto == null)
            {
                return new JsonResult(new
                {
                    message = $"Producto con el ID {producto.Id} no existe",
                    ProductoNuevo = ""
                });
            }

            HistorialInventario historial = new HistorialInventario();
            historial.ProductoId = product.Id;
            historial.FechaHoraCambio = DateTime.Now;
            historial.TipoCambio = motivo;

                      // Actualizar propiedades del producto
            producto.Nombre = product.Nombre ?? producto.Nombre;
            producto.Precio = product.Precio ?? producto.Precio;
            producto.Categoria = product.Categoria ?? producto.Categoria;
            producto.Descripcion = product.Descripcion ?? producto.Descripcion;
            producto.imagen = product.imagen ?? producto.imagen;

            context.HistorialInventarios.Add(historial);
            await context.SaveChangesAsync();

            return new JsonResult(new
            {
                message = $"Producto con el ID {producto.Id} cambiado con éxito",
                ProductoNuevo = ""
            });
        }
    }
}
