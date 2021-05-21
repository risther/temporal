namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("HorarioAtencionDia")]
    public partial class HorarioAtencionDia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HorarioAtencionDia()
        {
            DetalleCita = new HashSet<DetalleCita>();
            HorarioAtencion = new HashSet<HorarioAtencion>();
        }

        [Key]
        public int horarioAtencionDia_id { get; set; }

        public int horarioAtencionDetalle_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCita> DetalleCita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioAtencion> HorarioAtencion { get; set; }

        public virtual HorarioAtencionDetalle HorarioAtencionDetalle { get; set; }

        public List<HorarioAtencionDia> Listar() //Retorna varios objetos
        {
            var objUsuario = new List<HorarioAtencionDia>();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.HorarioAtencionDia.ToList();
                }
            }
            catch (Exception eX)
            {

                throw;
            }
            //3. Devolvemos los objetos
            return objUsuario;
        }
    }
}
