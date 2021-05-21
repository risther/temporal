namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HorarioAtencionDetalle")]
    public partial class HorarioAtencionDetalle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HorarioAtencionDetalle()
        {
            HorarioAtencionDia = new HashSet<HorarioAtencionDia>();
        }

        [Key]
        public int horarioAtencionDetalle_id { get; set; }

        public TimeSpan? horaInicio { get; set; }

        public TimeSpan? horaFinal { get; set; }

        [StringLength(1)]
        public string disponibilidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioAtencionDia> HorarioAtencionDia { get; set; }
    }
}
