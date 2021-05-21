using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasMedicas.Models;

namespace SistemaCitasMedicas.Controllers
{
    public class HorarioAtencionController : Controller
    {
        private Especialista objEspecialista = new Especialista();
       private HorarioAtencionDia objHorarioDia = new HorarioAtencionDia();
        private HorarioAtencion objAtencion = new HorarioAtencion();
        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objAtencion.Listar());
            }
            else
            {
                return View(objAtencion.Listar());
                //return View(objAtencion.Buscar(criterio));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objAtencion.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Especialista = objEspecialista.Listar();
            ViewBag.Dia = objHorarioDia.Listar();

            return View(id == 0 ? new HorarioAtencion() // Agregarmos un nuevo objeto
               : objAtencion.Obtener(id) //Devuelve el id del objeto
               );
        }

        public ActionResult Guardar(HorarioAtencion objAtencion)
        {
            if (ModelState.IsValid)
            {
                objAtencion.Guardar();
                return Redirect("~/HorarioAtencion");
            }
            else
            {
                return View("~/Views/HorarioAtencion/AgregarEditar.cshtml", objAtencion);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objAtencion.especialista_id = id;
            objAtencion.Eliminar();
            return Redirect("~/HorarioAtencion");
        }
    }
}