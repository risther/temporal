namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Calificacion")]
    public partial class Calificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int calificacion_id { get; set; }

        public int calficacion { get; set; }

        public int especialista_id { get; set; }

        [Required]
        [StringLength(500)]
        public string comentario { get; set; }

        public int usuario_id { get; set; }

        public virtual Especialista Especialista { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
