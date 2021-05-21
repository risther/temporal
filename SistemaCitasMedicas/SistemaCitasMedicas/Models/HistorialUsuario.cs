namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HistorialUsuario")]
    public partial class HistorialUsuario
    {
        [Key]
        public int historialUsuario_id { get; set; }

        public int cita_id { get; set; }

        public virtual Cita Cita { get; set; }
    }
}
