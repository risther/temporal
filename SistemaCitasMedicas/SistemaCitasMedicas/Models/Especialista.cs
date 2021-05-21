namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Especialista")]
    public partial class Especialista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Especialista()
        {
            Calificacion = new HashSet<Calificacion>();
            DetalleCita = new HashSet<DetalleCita>();
            HorarioAtencion = new HashSet<HorarioAtencion>();
            RecetaMedica = new HashSet<RecetaMedica>();
        }

        [Key]
        public int especialista_id { get; set; }

        public int tipoEspecialista_id { get; set; }

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

        public virtual TipoEspecialista TipoEspecialista { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioAtencion> HorarioAtencion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecetaMedica> RecetaMedica { get; set; }

        //LOGIN

        public bool ValidarLogin(string correo, string contrasenia) //Retorna varios objetos
        {
            var objUsuario = new List<Especialista>();
            bool val = false;
            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.Especialista
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
        public List<Especialista> Listar() //Retorna varios objetos
        {
            var objEspecialista = new List<Especialista>();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objEspecialista = db.Especialista.ToList();
                }
            }
            catch (Exception eX)
            {

                throw;
            }
            //3. Devolvemos los objetos
            return objEspecialista;
        }



        //Metodo obtener
        public Especialista Obtener(int id) //Retorna varios objetos
        {
            var objEspecialista = new Especialista();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objEspecialista = db.Especialista
                        .Where(x => x.especialista_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception eX)
            {

                throw;
            }
            //3. Devolvemos el objeto
            return objEspecialista;
        }
        //Metodo BUSCAR
        public List<Especialista> Buscar(string criterio) //Retorna varios objetos
        {
            var objEspecialista = new List<Especialista>();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objEspecialista = db.Especialista
                        .Where(x => x.nombre.Contains(criterio) || x.dni.Equals(criterio)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //3. Devolvemos los objetos
            return objEspecialista;
        }

        //Metodo guardar
        public void Guardar()
        {
            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    if (this.especialista_id > 0) //Existe el id
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
