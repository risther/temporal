namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleCita")]
    public partial class DetalleCita
    {
        [Key]
        public int cita_id { get; set; }

        public int especialista_id { get; set; }

        public int usuario_id { get; set; }

        public int horarioAtencionDia_id { get; set; }

        public virtual Especialista Especialista { get; set; }

        public virtual HorarioAtencionDia HorarioAtencionDia { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
