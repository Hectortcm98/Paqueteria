using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ServicioClienteController : Controller
    {
        // GET: ServicioCliente
        public ActionResult ServicioACliente()
        {
            // Mostrar la vista sin ningún modelo de paquete
            return View();
        }

        [HttpPost]
        public ActionResult ServicioACliente(string NumeroGuia)
        {
            // Verificar si se proporciona un código válido
            if (!string.IsNullOrEmpty(NumeroGuia))
            {
                // Intentar buscar el paquete por el código proporcionado
                var resultado = BL.Paquete.GetByNumeroGuia(NumeroGuia);

                if (resultado.Item1)
                {
                    // Si se encuentra el paquete, mostrar la vista con el paquete encontrado
                    return View("Principal", resultado.Item3);
                }
            }

            // Si no se proporciona un código válido o si no se encuentra el paquete, mostrar la vista sin ningún modelo de paquete
            return View("Principal");
        }

        public ActionResult PreguntasFrecuentes()
        {
           
            return View();
        }



        [HttpPost]
        public ActionResult EnviarCorreo(string name, string email, string subject, string message)
        {
            // Llamamos al método para enviar el correo electrónico
            EnviarCorreoElectronico(name, email, subject, message);

            // Redireccionamos a una página de agradecimiento o a donde desees
            ViewBag.Text = "Se envio con exito";
            return PartialView("Modal");
        }

       

        private void EnviarCorreoElectronico(string name, string email, string subject, string message)
        {
            try
            {
                // Configuración del correo electrónico
                string destinatario = "willmen99@gmail.com";
                string cuerpoMensaje = $"Nombre: {name}\n" +
                                       $"Correo Electrónico: {email}\n" +
                                       $"Asunto: {subject}\n\n" +
                                       $"Mensaje:\n{message}";

                // Crear objeto de correo electrónico
                MailMessage correo = new MailMessage(email, destinatario, subject, cuerpoMensaje);

                // Configurar cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("willmen99@gmail.com", "rklkzaahmfffssql"),
                    EnableSsl = true
                };

                // Enviar correo electrónico
                clienteSmtp.Send(correo);
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes registrar el error en el sistema de registro o manejarlo de otra manera
                // Aquí puedes agregar código para manejar el error de manera adecuada
                throw new Exception("Error al enviar correo electrónico.", ex);
            }
        }

    }
}
    
