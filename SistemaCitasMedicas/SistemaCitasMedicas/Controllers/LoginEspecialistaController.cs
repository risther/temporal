using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasMedicas.Models;
namespace SistemaCitasMedicas.Controllers
{
    public class LoginEspecialistaController : Controller
    {
        private Especialista objEspecialista = new Especialista();
        //private TipoUsuario objTipoUsuario = new TipoUsuario();
       // private TipoEspecialista objTipoEspecialista = new TipoEspecialista();
        // GET: Semestre
        public ActionResult Index(string correo, string contrasenia)
        {
            if (contrasenia == "" || contrasenia == null || correo == "" || correo == null)
            {
                return View();
            }

            else
            {
                if (objEspecialista.ValidarLogin(correo, contrasenia) == true)
                {
                    return Redirect("~/Especialista");
                }
                else
                {

                    return View();
                }

            }
        }
        public ActionResult AgregarUsuario(int id = 0)
        {
            //ViewBag.TipoUsuario = objTipoUsuario.Listar();

            return View(id == 0 ? new Especialista() // Agregarmos un nuevo objeto
                : objEspecialista.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(Especialista objEspecialista)
        {
            if (ModelState.IsValid)
            {
                objEspecialista.Guardar();
                return Redirect("~/LoginEspecialista");
            }
            else
            {
                return View("~/Views/LoginEspecialista/AgregarUsuario.cshtml", objEspecialista);
            }
        }
    }
}