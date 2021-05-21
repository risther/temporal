using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasMedicas.Models;
namespace SistemaCitasMedicas.Controllers
{
    public class LoginAdministradorController : Controller
    {
        // GET: LoginUsuario
        private Usuario objUsuario = new Usuario();
        // GET: Semestre
        public ActionResult Index(string correo, string contrasenia)
        {
            if (contrasenia == "" || contrasenia == null || correo == "" || correo == null)
            {
                return View();
            }

            else
            {
                if (objUsuario.ValidarAdmin(correo, contrasenia) == true)
                {
                    return Redirect("~/Usuario");
                }
                else
                {

                    return View();
                }

            }
        }
       
    }
}