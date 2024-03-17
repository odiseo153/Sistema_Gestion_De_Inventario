
namespace Core.Entities;

public partial class Usuario : BaseEntity
{

    public string? Nombre { get; set; }

    public string? Contraseña { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<HistorialInventario> HistorialInventarios { get; set; } = new List<HistorialInventario>();
}
