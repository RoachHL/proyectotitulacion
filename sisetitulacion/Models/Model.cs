using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace sisetitulacion.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Modeltitulacion")
        {
        }

        public virtual DbSet<TBL_Cliente> TBL_Cliente { get; set; }
        public virtual DbSet<TBL_DetalleGuia> TBL_DetalleGuia { get; set; }
        public virtual DbSet<TBL_DetalleRecibo> TBL_DetalleRecibo { get; set; }
        public virtual DbSet<TBL_Distrito> TBL_Distrito { get; set; }
        public virtual DbSet<TBL_Empleado> TBL_Empleado { get; set; }
        public virtual DbSet<TBL_Equipo> TBL_Equipo { get; set; }
        public virtual DbSet<TBL_GuiaEntrada> TBL_GuiaEntrada { get; set; }
        public virtual DbSet<TBL_Marca> TBL_Marca { get; set; }
        public virtual DbSet<TBL_ReciboRecojo> TBL_ReciboRecojo { get; set; }
        public virtual DbSet<TBL_TipoEquipo> TBL_TipoEquipo { get; set; }
        public virtual DbSet<TBL_tipoUsuario> TBL_tipoUsuario { get; set; }
        public virtual DbSet<TBL_Trabajo> TBL_Trabajo { get; set; }
        public virtual DbSet<TBL_Usuario> TBL_Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBL_Cliente>()
                .Property(e => e.Tipo_documento)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Cliente>()
                .Property(e => e.Numero_Documento)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Cliente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Cliente>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Cliente>()
                .HasMany(e => e.TBL_Equipo)
                .WithOptional(e => e.TBL_Cliente)
                .HasForeignKey(e => e.Cliente);

            modelBuilder.Entity<TBL_Cliente>()
                .HasMany(e => e.TBL_GuiaEntrada)
                .WithOptional(e => e.TBL_Cliente)
                .HasForeignKey(e => e.Cliente);

            modelBuilder.Entity<TBL_Cliente>()
                .HasMany(e => e.TBL_ReciboRecojo)
                .WithOptional(e => e.TBL_Cliente)
                .HasForeignKey(e => e.cliente);

            modelBuilder.Entity<TBL_DetalleGuia>()
                .Property(e => e.precio)
                .HasPrecision(10, 4);

            modelBuilder.Entity<TBL_DetalleRecibo>()
                .Property(e => e.precio)
                .HasPrecision(10, 4);

            modelBuilder.Entity<TBL_Distrito>()
                .HasMany(e => e.TBL_Cliente)
                .WithOptional(e => e.TBL_Distrito)
                .HasForeignKey(e => e.Distrito);

            modelBuilder.Entity<TBL_Distrito>()
                .HasMany(e => e.TBL_Empleado)
                .WithOptional(e => e.TBL_Distrito)
                .HasForeignKey(e => e.Distrito);

            modelBuilder.Entity<TBL_Empleado>()
                .Property(e => e.dni)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Empleado>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Empleado>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Empleado>()
                .HasMany(e => e.TBL_GuiaEntrada)
                .WithOptional(e => e.TBL_Empleado)
                .HasForeignKey(e => e.empleado);

            modelBuilder.Entity<TBL_Empleado>()
                .HasMany(e => e.TBL_ReciboRecojo)
                .WithOptional(e => e.TBL_Empleado)
                .HasForeignKey(e => e.empleado);

            modelBuilder.Entity<TBL_Equipo>()
                .HasMany(e => e.TBL_GuiaEntrada)
                .WithOptional(e => e.TBL_Equipo)
                .HasForeignKey(e => e.equipocl);

            modelBuilder.Entity<TBL_GuiaEntrada>()
                .Property(e => e.empleado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_GuiaEntrada>()
                .HasMany(e => e.TBL_DetalleGuia)
                .WithOptional(e => e.TBL_GuiaEntrada)
                .HasForeignKey(e => e.numguia);

            modelBuilder.Entity<TBL_Marca>()
                .HasMany(e => e.TBL_Equipo)
                .WithOptional(e => e.TBL_Marca)
                .HasForeignKey(e => e.marca);

            modelBuilder.Entity<TBL_ReciboRecojo>()
                .Property(e => e.empleado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ReciboRecojo>()
                .Property(e => e.total)
                .HasPrecision(10, 4);

            modelBuilder.Entity<TBL_ReciboRecojo>()
                .HasMany(e => e.TBL_DetalleRecibo)
                .WithOptional(e => e.TBL_ReciboRecojo)
                .HasForeignKey(e => e.recibo);

            modelBuilder.Entity<TBL_TipoEquipo>()
                .HasMany(e => e.TBL_Equipo)
                .WithOptional(e => e.TBL_TipoEquipo)
                .HasForeignKey(e => e.tipoequipo);

            modelBuilder.Entity<TBL_tipoUsuario>()
                .HasMany(e => e.TBL_Usuario)
                .WithOptional(e => e.TBL_tipoUsuario)
                .HasForeignKey(e => e.TipoUsuario);

            modelBuilder.Entity<TBL_Trabajo>()
                .Property(e => e.precio)
                .HasPrecision(10, 4);

            modelBuilder.Entity<TBL_Trabajo>()
                .HasMany(e => e.TBL_DetalleGuia)
                .WithOptional(e => e.TBL_Trabajo)
                .HasForeignKey(e => e.trabajo);
        }
    }
}
