
namespace Core.Entities;

public partial class HistorialInventario : BaseEntity
{

    public Guid? ProductoId { get; set; }

    public DateTime? FechaHoraCambio { get; set; }

    public string? TipoCambio { get; set; }

    public int? CantidadAnterior { get; set; }

    public Guid? CantidadNueva { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Usuario? UsuarioCambio { get; set; }
}
