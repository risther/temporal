using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasMedicas.Models;

namespace SistemaCitasMedicas.Controllers
{
    public class EspecialistaController : Controller
    {
        private Especialista objEspecialista = new Especialista();
        private TipoUsuario objTipoUsuario = new TipoUsuario();
        private TipoEspecialista objTipoEspecialista = new TipoEspecialista();
        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objEspecialista.Listar());
            }
            else
            {
                return View(objEspecialista.Buscar(criterio));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objEspecialista.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.tipoUsuario = objTipoUsuario.Listar();
            ViewBag.tipoEspecialista = objTipoEspecialista.Listar();
            
            return View(id == 0 ? new Especialista() // Agregarmos un nuevo objeto
                : objEspecialista.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(Especialista objEspecialista)
        {
            if (ModelState.IsValid)
            {
                objEspecialista.Guardar();
                return Redirect("~/Especialista");
            }
            else
            {
                return View("~/Views/Especialista/AgregarEditar.cshtml", objEspecialista);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objEspecialista.especialista_id = id;
            objEspecialista.Eliminar();
            return Redirect("~/Especialista");
        }
    }
}