namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Calificacion = new HashSet<Calificacion>();
            DetalleCita = new HashSet<DetalleCita>();
            RecetaMedica = new HashSet<RecetaMedica>();
        }

        [Key]
        public int usuario_id { get; set; }

        public int tipoUsuario_id { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string apellido { get; set; }

        [StringLength(9)]
        public string telefono { get; set; }

        [Required]
        [StringLength(250)]
        public string correo { get; set; }

        [Required]
        [StringLength(250)]
        public string contrasenia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calificacion> Calificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCita> DetalleCita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecetaMedica> RecetaMedica { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }

        //LOGIN

        public bool ValidarLogin(string correo,string contrasenia) //Retorna varios objetos
        {
            var objUsuario = new List<Usuario>();
            bool val = false;
            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.Usuario
                        .Where(x => x.contrasenia.Equals(contrasenia) || x.correo.Equals(correo)

                        ).ToList();
                    
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }

            foreach (var item in objUsuario)
            {
                if (item.correo.Equals(correo) && item.contrasenia.Equals(contrasenia))
                {
                    val = true;
                }
                else
                {
                    val = false;
                }
            }
            //3. Devolvemos los objetos
            return val;
        }

        public bool ValidarAdmin(string correo, string contrasenia) //Retorna varios objetos
        {
            var objUsuario = new List<Usuario>();
            bool val = false;
            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.Usuario
                        .Where(x => x.contrasenia.Equals(contrasenia) || x.correo.Equals(correo)

                        ).ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            foreach (var item in objUsuario)
            {
                if (item.correo.Equals(correo) && item.contrasenia.Equals(contrasenia))
                {
                    val = true;
                }
                else
                {
                    val = false;
                }
            }
            //3. Devolvemos los objetos
            return val;
        }
        //Metodo CRUD
        public List<Usuario> Listar() //Retorna varios objetos
        {
            var objUsuario = new List<Usuario>();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.Usuario.ToList();
                }
            }
            catch (Exception eX)
            {

                throw;
            }
            //3. Devolvemos los objetos
            return objUsuario;
        }



        //Metodo obtener
        public Usuario Obtener(int id) //Retorna varios objetos
        {
            var objUsuario = new Usuario();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.Usuario
                        .Where(x => x.usuario_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception eX)
            {

                throw;
            }
            //3. Devolvemos el objeto
            return objUsuario;
        }
        //Metodo BUSCAR
        public List<Usuario> Buscar(string criterio) //Retorna varios objetos
        {
            var objUsuario = new List<Usuario>();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.Usuario
                        .Where(x => x.nombre.Contains(criterio) || x.dni.Equals(criterio) || x.usuario_id.Equals(criterio) || x.contrasenia.Equals(criterio) || x.correo.Equals(criterio)

                        ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //3. Devolvemos los objetos
            return objUsuario;
        }

        //Metodo guardar
        public void Guardar()
        {
            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    if (this.usuario_id > 0) //Existe el id
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        //Metodo Eliminar

        public void Eliminar()
        {
            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception eX)
            {

                throw;
            }
        }

    }
}
