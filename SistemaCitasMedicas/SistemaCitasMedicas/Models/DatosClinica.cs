namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatosClinica")]
    public partial class DatosClinica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatosClinica()
        {
            RecetaMedica = new HashSet<RecetaMedica>();
        }

        [Key]
        public int datosClinica_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string direccion { get; set; }

        [Required]
        [StringLength(9)]
        public string telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecetaMedica> RecetaMedica { get; set; }
    }
}
