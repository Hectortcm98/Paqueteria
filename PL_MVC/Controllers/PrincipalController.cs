using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Path = System.IO.Path;
using System.Net.Mail;
using System.Net;

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
        public ActionResult Principal(string NumeroGuia)
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

        public ActionResult GenerarPDF(int paqueteId)
        {
            // Obtener los datos del paquete utilizando la lógica de negocios (BL)
            var resultado = BL.Paquete.GetByIdLINQ(paqueteId);

            if (resultado.Item1) // Si la operación fue exitosa
            {
                ML.Paquete paquete = resultado.Item3; // Obtén el paquete desde el resultado

                // Crear un nuevo documento PDF en una ubicación temporal
                string rutaTempPDF = Path.GetTempFileName() + ".pdf";

                using (PdfDocument pdfDocument = new PdfDocument(new PdfWriter(rutaTempPDF)))
                {
                    using (Document document = new Document(pdfDocument))
                    {
                        // Agregar título
                        document.Add(new Paragraph("Detalle del Paquete")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(20)
                            .SetFontColor(ColorConstants.BLUE));

                        string rutaImagen = "C:\\Users\\digis\\Documents\\Hector Antonio Canales Mejia\\HCanalesProgramacionCapas\\PL_MVC\\Imagen\\cajaCaje_1.png"; // Cambia esto a la ruta de tu imagen
                        Image imagen = new Image(ImageDataFactory.Create(rutaImagen));

                        // Configura el tamaño de la imagen si es necesario
                        imagen.SetWidth(100); // Ancho de la imagen en puntos
                        imagen.SetHeight(100); // Alto de la imagen en puntos

                        // Centra horizontalmente la imagen
                        imagen.SetHorizontalAlignment(HorizontalAlignment.CENTER);

                        // Añade la imagen al documento
                        document.Add(imagen);

                        // Crear una tabla para mostrar los detalles del paquete
                        Table table = new Table(2); // 2 columnas
                        table.SetWidth(UnitValue.CreatePercentValue(100)); // Ancho de la tabla al 100% del documento

                        // Añadir las celdas de datos del paquete a la tabla
                        table.AddCell("Código:");
                        table.AddCell(paquete.CodigoQR);

                        table.AddCell("Instrucción de Entrega:");
                        table.AddCell(paquete.InstruccionEntrega);

                        table.AddCell("Peso:");
                        table.AddCell(paquete.Peso.ToString());

                        table.AddCell("Número de Guía:");
                        table.AddCell(paquete.NumeroGuia);

                        table.AddCell("Origen:");
                        table.AddCell(paquete.DireccionOrigen);

                        table.AddCell("Entrega:");
                        table.AddCell(paquete.DireccionEntrega);

                        table.AddCell("Fecha de Entrega:");
                        table.AddCell(paquete.FechaEstimadaEntrega.ToString());

                        
                        // Añadir la tabla al documento
                        document.Add(table);

                       

                    }
                }

                // Leer el archivo PDF como un arreglo de bytes
                byte[] fileBytes = System.IO.File.ReadAllBytes(rutaTempPDF);

                // Eliminar el archivo temporal
                System.IO.File.Delete(rutaTempPDF);
                
                // Descargar el archivo PDF
                return new FileStreamResult(new MemoryStream(fileBytes), "application/pdf")
                {
                    FileDownloadName = "DetallePaquete.pdf"
                };
            }
            else // Si ocurrió un error al obtener el paquete
            {
                // Manejar el error de acuerdo a tus necesidades
                throw new Exception("Error al obtener el paquete por ID: " + resultado.Item2);
            }
        }



        [HttpPost]
        public ActionResult CapturarMapa(string mapaImagen)
        {
            // Aquí puedes manejar la imagen recibida, como guardarla en el servidor o agregarla al PDF
            // La imagen del mapa llegará como una cadena base64 en el parámetro 'mapaImagen'

            return RedirectToAction("Principal"); // O devuelve una respuesta adecuada
        }


    }
}






