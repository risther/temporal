using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasMedicas.Models;
namespace SistemaCitasMedicas.Controllers
{
    public class LoginUsuarioController : Controller
    {
        // GET: LoginUsuario
        private Usuario objUsuario = new Usuario();
        // GET: Semestre
        public ActionResult Index(string correo,string contrasenia)
        {
            if (contrasenia=="" || contrasenia==null ||correo=="" || correo == null)
            {
                return View();
            }
            
            else
            {
                if (objUsuario.ValidarLogin(correo, contrasenia) == true)
                {
                    return Redirect("~/Usuario");
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

            return View(id == 0 ? new Usuario() // Agregarmos un nuevo objeto
                : objUsuario.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(Usuario objUsuario)
        {
            if (ModelState.IsValid)
            {
                objUsuario.Guardar();
                return Redirect("~/LoginUsuario");
            }
            else
            {
                return View("~/Views/LoginUsuario/AgregarUsuario.cshtml", objUsuario);
            }
        }


      


    }
}