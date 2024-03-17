

namespace Application.Alertas.Update
{
    public class UpdateAlertaCommand : IRequest<Alerta>
    {
        public Guid Id { get; set; }
        public string? TipoAlerta { get; set; }

        public string? Descripcion { get; set; }
    }
}
