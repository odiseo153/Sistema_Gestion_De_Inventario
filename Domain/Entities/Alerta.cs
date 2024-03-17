
namespace Core.Entities;

public partial class Alerta : BaseEntity
{
    public string? TipoAlerta { get; set; }

    public DateTime? FechaHoraAlerta { get; set; }

    public string? Descripcion { get; set; }

    public Guid? ProductoRelacionadoId { get; set; }

    public virtual Producto? ProductoRelacionado { get; set; }
}
