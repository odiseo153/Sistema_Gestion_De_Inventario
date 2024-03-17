using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core.Metadata.Edm;

namespace Infraestructure.Context;

public partial class SistemaGestionContext : DbContext
{

    private string oracleConnection = "User Id=C##odiseo;Password=padomo153;Data Source=Odiseo;";
    private string sqlServerConnection = "Server=odiseo\\ODISEO;Database=SistemaGestion;User Id=sa;Password=1234;TrustServerCertificate=True;";
    
    public SistemaGestionContext()
    {
    }

    public SistemaGestionContext(DbContextOptions<SistemaGestionContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<Alerta> Alertas { get; set; }

    public virtual DbSet<HistorialInventario> HistorialInventarios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(sqlServerConnection);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Alerta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alertas__3214EC273020B4AE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaHoraAlerta).HasColumnType("datetime");
            entity.Property(e => e.ProductoRelacionadoId).HasColumnName("ProductoRelacionadoID");
            entity.Property(e => e.TipoAlerta).HasMaxLength(50);

            entity.HasOne(d => d.ProductoRelacionado).WithMany(p => p.Alerta)
                .HasForeignKey(d => d.ProductoRelacionadoId)
                .HasConstraintName("FK__Alertas__Product__2B3F6F97");
        });

        modelBuilder.Entity<HistorialInventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC273C8A695F");

            entity.ToTable("HistorialInventario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaHoraCambio).HasColumnType("datetime");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.TipoCambio).HasMaxLength(50);

            entity.HasOne(d => d.Producto).WithMany(p => p.HistorialInventarios)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Historial__Produ__2E1BDC42");
                

        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC27285BE102");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasMany(d => d.HistorialInventarios)
            .WithOne(d =>d.Producto)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(d => d.Transacciones)
            .WithOne(d => d.Producto)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(d => d.Alerta)
            .WithOne(d => d.ProductoRelacionado)
            .OnDelete(DeleteBehavior.Cascade);

        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transacc__3214EC273684C660");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaHoraTransaccion).HasColumnType("datetime");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.TipoTransaccion).HasMaxLength(50);

            entity.HasOne(d => d.Producto).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Transacci__Produ__267ABA7A");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC27F3C6D75B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });
 

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
