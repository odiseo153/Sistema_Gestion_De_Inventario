
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Data.Entity;
using Microsoft.AspNetCore.Http;

namespace Infraestructure.Repositorie
{
    public class AlertaRepositorie : IAlertaRepository
    {
        private SistemaGestionContext context;

        public AlertaRepositorie(SistemaGestionContext context)
        {
            this.context = context;
        }


        public async Task<Alerta> CreateAlerta(Alerta alerta)
        {
            alerta.FechaHoraAlerta = DateTime.Now;

            await context.Alertas.AddAsync(alerta);
            await context.SaveChangesAsync();

            return alerta;
        }

        public async Task<IActionResult> DeleteAlertas(Guid Id)
        {
            var alerta = context.Alertas.Find(Id);

            try
            {
                context.Alertas.Remove(alerta);
                await context.SaveChangesAsync();

                return new JsonResult(new
                {
                    message = "Alerta borrada con exito",
                    code = StatusCodes.Status200OK
                });
            }
            catch(Exception ex) 
            {
                return new JsonResult(new
                {
                    message = "Hubo un error en borrar la alerta",
                    ErrorMessage = ex.Message,
                    code = StatusCodes.Status500InternalServerError
                });
            }
        }

        public async Task<IActionResult> GetAllAlerta()
        {
            var alerta = context.Alertas.Include(x => x.ProductoRelacionado).AsEnumerable();
      
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                
            };
       
            var jsonString = JsonSerializer.Serialize(alerta, options);

            return new ContentResult
            {
                Content = jsonString,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        public async Task<Alerta> UpdateAlertas(Alerta alerta)
        {
            var alertas = context.Alertas.SingleOrDefault(x => x.Id == alerta.Id);

            alertas.Descripcion = alerta.Descripcion ?? alertas.Descripcion;
            alertas.TipoAlerta = alerta.TipoAlerta ?? alertas.TipoAlerta;
            

           await context.SaveChangesAsync();

            return alertas;
        }
    }
}
