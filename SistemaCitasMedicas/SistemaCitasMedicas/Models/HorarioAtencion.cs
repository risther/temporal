namespace SistemaCitasMedicas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("HorarioAtencion")]
    public partial class HorarioAtencion
    {
        [Key]
        public int horarioAtencion_id { get; set; }

        public int especialista_id { get; set; }

        public int horarioAtencionDia_id { get; set; }

        public virtual Especialista Especialista { get; set; }

        public virtual HorarioAtencionDia HorarioAtencionDia { get; set; }

        //Metodo CRUD
        public List<HorarioAtencion> Listar() //Retorna varios objetos
        {
            var objHorarioAtencion = new List<HorarioAtencion>();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objHorarioAtencion = db.HorarioAtencion.Include("HorarioAtencionDia")
                        .ToList();
                }
            }
            catch (Exception eX)
            {

                throw;
            }
            //3. Devolvemos los objetos
            return objHorarioAtencion;
        }



        //Metodo obtener
        public HorarioAtencion Obtener(int id) //Retorna varios objetos
        {
            var objHorarioAtencion = new HorarioAtencion();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objHorarioAtencion = db.HorarioAtencion
                        .Where(x => x.horarioAtencion_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception eX)
            {

                throw;
            }
            //3. Devolvemos el objeto
            return objHorarioAtencion;
        }
        //Metodo BUSCAR
        /*public List<HorarioAtencion> Buscar(string criterio) //Retorna varios objetos
        {
            var objHorarioAtencion = new List<HorarioAtencion>();

            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    //2. Sentencia de LinQ
                    objHorarioAtencion = db.HorarioAtencion
                        .Where(x => x.nombre.Contains(criterio) || x.dni.Equals(criterio)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //3. Devolvemos los objetos
            return objHorarioAtencion;
        }*/

        //Metodo guardar
        public void Guardar()
        {
            try
            {
                //1.Origen de datos
                using (var db = new ReservaCita())
                {
                    if (this.horarioAtencion_id > 0) //Existe el id
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
