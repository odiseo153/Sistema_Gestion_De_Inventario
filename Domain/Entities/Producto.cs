
namespace Core.Entities;

public partial class Producto : BaseEntity
{

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string? imagen { get; set; }

    public string? Categoria { get; set; }

    public virtual ICollection<Alerta> Alerta { get; set; } = new List<Alerta>();

    public virtual ICollection<HistorialInventario> HistorialInventarios { get; set; } = new List<HistorialInventario>();

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
