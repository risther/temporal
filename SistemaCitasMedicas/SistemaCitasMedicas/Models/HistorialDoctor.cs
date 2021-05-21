namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HistorialDoctor")]
    public partial class HistorialDoctor
    {
        [Key]
        public int historialDoctor_id { get; set; }

        public int cita_id { get; set; }

        public virtual Cita Cita { get; set; }
    }
}
