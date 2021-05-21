using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SistemaCitasMedicas.Models
{
    public partial class ReservaCita : DbContext
    {
        public ReservaCita()
            : base("name=ReservaCita")
        {
        }

        public virtual DbSet<Calificacion> Calificacion { get; set; }
        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<DatosClinica> DatosClinica { get; set; }
        public virtual DbSet<DetalleCita> DetalleCita { get; set; }
        public virtual DbSet<Especialista> Especialista { get; set; }
        public virtual DbSet<HistorialDoctor> HistorialDoctor { get; set; }
        public virtual DbSet<HistorialUsuario> HistorialUsuario { get; set; }
        public virtual DbSet<HorarioAtencion> HorarioAtencion { get; set; }
        public virtual DbSet<HorarioAtencionDetalle> HorarioAtencionDetalle { get; set; }
        public virtual DbSet<HorarioAtencionDia> HorarioAtencionDia { get; set; }
        public virtual DbSet<RecetaMedica> RecetaMedica { get; set; }
        public virtual DbSet<TipoEspecialista> TipoEspecialista { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<RecetaMedicaDetalle> RecetaMedicaDetalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacion>()
                .Property(e => e.comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Cita>()
                .Property(e => e.estadoAtencion)
                .IsUnicode(false);

            modelBuilder.Entity<Cita>()
                .HasMany(e => e.HistorialDoctor)
                .WithRequired(e => e.Cita)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cita>()
                .HasMany(e => e.HistorialUsuario)
                .WithRequired(e => e.Cita)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DatosClinica>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<DatosClinica>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<DatosClinica>()
                .Property(e => e.telefono)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DatosClinica>()
                .HasMany(e => e.RecetaMedica)
                .WithRequired(e => e.DatosClinica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialista>()
                .Property(e => e.dni)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Especialista>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Especialista>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Especialista>()
                .Property(e => e.telefono)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Especialista>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Especialista>()
                .Property(e => e.contrasenia)
                .IsUnicode(false);

            modelBuilder.Entity<Especialista>()
                .HasMany(e => e.Calificacion)
                .WithRequired(e => e.Especialista)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialista>()
                .HasMany(e => e.DetalleCita)
                .WithRequired(e => e.Especialista)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialista>()
                .HasMany(e => e.HorarioAtencion)
                .WithRequired(e => e.Especialista)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialista>()
                .HasMany(e => e.RecetaMedica)
                .WithRequired(e => e.Especialista)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HorarioAtencionDetalle>()
                .Property(e => e.disponibilidad)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HorarioAtencionDetalle>()
                .HasMany(e => e.HorarioAtencionDia)
                .WithRequired(e => e.HorarioAtencionDetalle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HorarioAtencionDia>()
                .HasMany(e => e.DetalleCita)
                .WithRequired(e => e.HorarioAtencionDia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HorarioAtencionDia>()
                .HasMany(e => e.HorarioAtencion)
                .WithRequired(e => e.HorarioAtencionDia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RecetaMedica>()
                .HasMany(e => e.RecetaMedicaDetalle)
                .WithRequired(e => e.RecetaMedica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoEspecialista>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoEspecialista>()
                .HasMany(e => e.Especialista)
                .WithRequired(e => e.TipoEspecialista)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoUsuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoUsuario>()
                .HasMany(e => e.Especialista)
                .WithRequired(e => e.TipoUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoUsuario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.TipoUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.dni)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.telefono)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.contrasenia)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Calificacion)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.DetalleCita)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.RecetaMedica)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RecetaMedicaDetalle>()
                .Property(e => e.peso)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RecetaMedicaDetalle>()
                .Property(e => e.talla)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RecetaMedicaDetalle>()
                .Property(e => e.diagnostico)
                .IsUnicode(false);

            modelBuilder.Entity<RecetaMedicaDetalle>()
                .Property(e => e.receta)
                .IsUnicode(false);
        }
    }
}
