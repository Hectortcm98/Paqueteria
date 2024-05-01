using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Principal()
            {
            // Mostrar la vista sin ningún modelo de paquete
            return View();
        }

        [HttpPost]
        public ActionResult Principal(string codigo)
        {
            // Verificar si se proporciona un código válido
            if (!string.IsNullOrEmpty(codigo))
            {
                // Intentar buscar el paquete por el código proporcionado
                var resultado = BL.Paquete.GetByCodigoLINQ(codigo);

                if (resultado.Item1)
                {
                    // Si se encuentra el paquete, mostrar la vista con el paquete encontrado
                    return View("Principal", resultado.Item3);
                }
            }

            // Si no se proporciona un código válido o si no se encuentra el paquete, mostrar la vista sin ningún modelo de paquete
            return View("Principal");
        }

    }
}