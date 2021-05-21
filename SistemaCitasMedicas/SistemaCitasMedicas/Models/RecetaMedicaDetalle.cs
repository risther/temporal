namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RecetaMedicaDetalle")]
    public partial class RecetaMedicaDetalle
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int recetaMedica_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal peso { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal talla { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(250)]
        public string diagnostico { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(500)]
        public string receta { get; set; }

        public virtual RecetaMedica RecetaMedica { get; set; }
    }
}
