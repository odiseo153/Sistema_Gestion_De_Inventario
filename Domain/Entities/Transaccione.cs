
namespace Core.Entities;

public partial class Transaccione : BaseEntity
{

    public string? TipoTransaccion { get; set; }

    public DateTime? FechaHoraTransaccion { get; set; }

    public Guid? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public string? Notas { get; set; }

    public virtual Producto? Producto { get; set; }
}
