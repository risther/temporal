namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("TipoEspecialista")]
    public partial class TipoEspecialista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoEspecialista()
        {
            Especialista = new HashSet<Especialista>();
        }

        [Key]
        public int tipoEspecialista_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Especialista> Especialista { get; set; }


        public List<TipoEspecialista> Listar() //Retorna varios objetos
        {
            var objUsuario = new List<TipoEspecialista>();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.TipoEspecialista.ToList();
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
