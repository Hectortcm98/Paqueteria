using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var result = BL.Usuario.GetByEmail(email);

            if (result.Item1)
            {
                var usuario = result.Item3;

                if (usuario.Password == password)
                {
                    // Obtener el nombre del rol del usuario
                    var rolNombre = usuario.Roll.NombreRoll;

                    // Guardar el rol del usuario en una variable de sesión
                    Session["UserRole"] = rolNombre;

                    // Redirigir a la vista correspondiente según el rol
                    return RedirectToAction("Index", "Home"); // Redirige al layout principal
                }
            }

            ViewBag.Text = "Los datos no son correctos";
            return PartialView("Modal");
        }





        // GET: 
        public ActionResult SendEmail_1()
        {

            return View();

        }

        public ActionResult Recuperar(string Email)
        {
            var result = BL.Usuario.GetByEmail(Email);

            if (result.Item1)
            {
                //enviar el correo de recuperación
                string path = Server.MapPath("~/Content/Template/UpdatePassword.html");

                string body = string.Empty;

                using (StreamReader reader = new StreamReader(path))
                {
                    body = reader.ReadToEnd();
                }

                body = body.Replace("{Correo}", Email);

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("willmen99@gmail.com", "rklkzaahmfffssql"),
                    EnableSsl = true
                };

                var mensaje = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress(Email),
                    Subject = "Recuperación de contraseña",
                    Body = body,
                    IsBodyHtml = true
                };

                mensaje.To.Add(Email);

                smtpClient.Send(mensaje);



            }
            else
            {
                ViewBag.Text = "Los datos que proporcionaste son correctos";
                return PartialView("Modal");

            }


            ViewBag.Text = "Se ha mandado un mesaje a tu correo";
            return PartialView("Modal");

        }



        // GET: Login/ResetPassword
        public ActionResult ResetPassword(string email)
        {
            ML.Usuario usuario = new ML.Usuario();
            {
                usuario.Email = email;

            };
            return View();
        }

        // POST: Login/ResetPassword
        [HttpPost]
        public ActionResult ResetPassword(string email, string password, string confirm_password)
        {
            // Verificar si las contraseñas coinciden
            if (password != confirm_password)
            {
                ViewBag.ErrorMessage = "Las contraseñas no coinciden.";
                return View();
            }

            // Crear un objeto de usuario con la información proporcionada
            ML.Usuario usuario = new ML.Usuario
            {
                Email = email,
                Password = password
            };

            // Llamar al método para actualizar la contraseña en la capa de lógica de negocios
            var result = BL.Usuario.UpdatePassword(usuario);

            if (result.Item1)
            {
                ViewBag.Text = "La contraseña se ha actulizado correctamente";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.ErrorMessage = result.Item2; // Mostrar el mensaje de error devuelto por el método de actualización
                return View();
            }
        }

    }
}