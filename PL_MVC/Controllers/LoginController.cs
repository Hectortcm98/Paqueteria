using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
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

            // Si las credenciales son incorrectas o si hay algún otro error, redirige a la vista de inicio de sesión
            ViewBag.ErrorMessage = "Correo electrónico o contraseña incorrectos.";
            return View();
        }
    




    // GET: 
    public ActionResult SendEmail_1()
        {

            return View();

        }

        public JsonResult Recuperar(string Email)
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
                //no enviar correo
                //vista Modal, correo no existe
            }

            return Json(new { success = true, redirectUrl = Url.Action("ResetPassword", "Login") });

        }


        // GET: Login
        public ActionResult ResetPassword()
        {

            return View();

        }

    }
}