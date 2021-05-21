namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HorarioAtencion")]
    public partial class HorarioAtencion
    {
        [Key]
        public int horarioAtencion_id { get; set; }

        public int especialista_id { get; set; }

        public int horarioAtencionDia_id { get; set; }

        public virtual Especialista Especialista { get; set; }

        public virtual HorarioAtencionDia HorarioAtencionDia { get; set; }
    }
}
