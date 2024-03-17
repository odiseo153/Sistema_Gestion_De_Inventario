

namespace Application.Alertas.Created
{
    public class CreatedAlertaCommand : IRequest<Alerta>
    {
        public string? TipoAlerta { get; set; }

        public string? Descripcion { get; set; }

        public Guid? ProductoRelacionadoId { get; set; }
    }
}
