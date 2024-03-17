

using System.Text.Json.Serialization;
using System.Text.Json;
using Infraestructure.Context;
using System.Data.Entity;


namespace Infraestructure.Repositorie
{
    public class HistorialInventarioRepositorie : IHistorialInventarioRepository
    {
        private SistemaGestionContext context;

        public HistorialInventarioRepositorie(SistemaGestionContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> GetAllHistorial()
        {
    
            var historial =  context.HistorialInventarios
                .Include(x => x.UsuarioCambio)
                .Include(x => x.Producto).ToList();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,

            };

            var jsonString = JsonSerializer.Serialize(historial, options);

            /*
            return new JsonResult(new ContentResult
            {
                Content = jsonString,
                ContentType = "application/json",
                StatusCode = 200
            });
            */

            return new JsonResult(historial);
        }
    }
}
