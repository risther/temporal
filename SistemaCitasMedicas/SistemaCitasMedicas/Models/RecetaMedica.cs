namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RecetaMedica")]
    public partial class RecetaMedica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RecetaMedica()
        {
            RecetaMedicaDetalle = new HashSet<RecetaMedicaDetalle>();
        }

        [Key]
        public int recetaMedica_id { get; set; }

        public int usuario_id { get; set; }

        public int especialista_id { get; set; }

        public int datosClinica_id { get; set; }

        public virtual DatosClinica DatosClinica { get; set; }

        public virtual Especialista Especialista { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecetaMedicaDetalle> RecetaMedicaDetalle { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
