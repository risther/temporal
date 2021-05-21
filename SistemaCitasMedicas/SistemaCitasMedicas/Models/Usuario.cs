namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Calificacion = new HashSet<Calificacion>();
            DetalleCita = new HashSet<DetalleCita>();
            RecetaMedica = new HashSet<RecetaMedica>();
        }

        [Key]
        public int usuario_id { get; set; }

        public int tipoUsuario_id { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string apellido { get; set; }

        [StringLength(9)]
        public string telefono { get; set; }

        [Required]
        [StringLength(250)]
        public string correo { get; set; }

        [Required]
        [StringLength(250)]
        public string contrasenia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calificacion> Calificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCita> DetalleCita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecetaMedica> RecetaMedica { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
