namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("TipoUsuario")]
    public partial class TipoUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoUsuario()
        {
            Especialista = new HashSet<Especialista>();
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int tipoUsuario_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Especialista> Especialista { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }


        public List<TipoUsuario> Listar() //Retorna varios objetos
        {
            var objUsuario = new List<TipoUsuario>();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.TipoUsuario.ToList();
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
