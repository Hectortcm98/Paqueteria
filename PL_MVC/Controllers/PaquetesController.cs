using ML;
using PL_MVC.ServiceReferencePaquete;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;


namespace PL_MVC.Controllers
{
    public class PaquetesController : Controller
    {

        //---------------------------------GetAll--------------------------------------------------------------------------------------------
        // GET: Paquetes
        //public ActionResult GetAll()
        //{
        //    var result = BL.Paquete.GetAllClient();
        //    var resultd = BL.Repartidor.GetAllEF();




        //        if (result.Item1 == true)
        //        {
        //            ML.Paquete paquete1 = new ML.Paquete();
        //            paquete1.paqueteLista = result.Item3;

        //            //Asignar la lista de repartidores al modelo Paquete
        //            paquete1.Repartidor = new ML.Repartidor();
        //            paquete1.Repartidor.Repartidores = resultd.Item3;

        //            return View(paquete1);


        //        }
        //        else
        //        {   //manda la lista de paquetes
        //            ML.Paquete paquete = new ML.Paquete();
        //            return View();
        //        }
        //    }
        //----------------------webapi-------------------------------------

        //public ActionResult GetAll()
        //    //WebService
        //{
        //    //var result = BL.Paquete.GetAllClient();
        //    var resultd = BL.Repartidor.GetAllEF();

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44327/api/");
        //        var responseTask = client.GetAsync("paquete/GetAll");
        //        responseTask.Wait();

        //        var result = responseTask.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<List<ML.Paquete>>();

        //            readTask.Wait();

        //            if(readTask.Result != null)
        //            {
        //                ML.Paquete paquete1 = new ML.Paquete();
        //                paquete1.paqueteLista = readTask.Result;

        //                paquete1.Repartidor = new ML.Repartidor();
        //                paquete1.Repartidor.Repartidores = resultd.Item3;

        //                return View(paquete1);

        //            }
        //            else
        //            {   //manda la lista de paquetes
        //                ML.Paquete paquete = new ML.Paquete();
        //                return View();
        //            }
        //        }

        //        return View();   

        //    }         

        //}

        //------------------------------------GetAll con WCF-----------------------------------------------------------------------------------------

        public ActionResult GetAll()
        //WebService
        {
            //var result = BL.Paquete.GetAllClient();
            var resultd = BL.Repartidor.GetAllEF();

            ServiceReferencePaquete.IPaquetes client = new ServiceReferencePaquete.PaquetesClient();



            var resultado = client.GetAll();
            if (resultado.Item1)
            {
                ML.Paquete paquete = new ML.Paquete();
                paquete.paqueteLista = resultado.Item3.ToList();

                paquete.Repartidor = new Repartidor();
                paquete.Repartidor.Repartidores = resultd.Item3.Repartidores;
                //paquete.Repartidor.Repartidores = resultd.Item3.tolis;

                return View(paquete);

            }

            return View();

        }

        //------------------------------------getbyid-----------------------------------------------------------------------------------------

        //[HttpGet]
        //public ActionResult Form(int? idPaquete)
        //{
        //    //intancear el modelo de paquete
        //    ML.Paquete paquete = new ML.Paquete();
        //    //instancear la lista de paquetes (Trae sus propiedades)
        //    List<ML.Paquete> paqueteLis = new List<ML.Paquete>();

        //    if (idPaquete != null)
        //    {
        //        //para mandar llamar a lo registro para editar por el id
        //        var resultPaquete = BL.Paquete.GetByIdLINQ(idPaquete.Value);
        //        paquete = resultPaquete.Item3;

        //        var resultadoPaquete = BL.Paquete.GetAllClient();
        //        paquete.paqueteLista = new List<ML.Paquete>();
        //        paqueteLis = resultadoPaquete.Item3;
        //        paquete.paqueteLista = paqueteLis;
        //        paquete.paqueteLista = resultadoPaquete.Item3;

        //        return View(paquete);

        //    }
        //    else
        //    {
        //        var resultado = BL.Paquete.GetAllClient();
        //        paquete.paqueteLista = new List<ML.Paquete>();
        //        paqueteLis = resultado.Item3;
        //        paquete.paqueteLista = paqueteLis;

        //        return View(paquete);
        //    }

        //}


        //----------------------webapi-------------------------------------
        //[HttpGet]
        ////Esto es para el WebService
        //public ActionResult Form(int? idPaquete)
        //{
        //    //intancear el modelo de paquete
        //    ML.Paquete paquete = new ML.Paquete();
        //    //instancear la lista de paquetes (Trae sus propiedades)
        //    List<ML.Paquete> paqueteLis = new List<ML.Paquete>();

        //    if (idPaquete != null)
        //    {
        //        //para mandar llamar a lo registro para editar por el id
        //        //var resultPaquete = BL.Paquete.GetByIdLINQ(idPaquete.Value);
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("https://localhost:44327/api/");
        //            var responseTask = client.GetAsync("paquete/GetById?IdPaquete= " + idPaquete);
        //            responseTask.Wait();

        //            var result = responseTask.Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                var resultadoPaquete = BL.Paquete.GetAllClient();
        //                paquete.paqueteLista = new List<ML.Paquete>();
        //                paqueteLis = resultadoPaquete.Item3;
        //                paquete.paqueteLista = paqueteLis;
        //                paquete.paqueteLista = resultadoPaquete.Item3;

        //                return View(paquete);

        //            }
        //            else
        //            {
        //                var resultado = BL.Paquete.GetAllClient();
        //                paquete.paqueteLista = new List<ML.Paquete>();
        //                paqueteLis = resultado.Item3;
        //                paquete.paqueteLista = paqueteLis;

        //                return View(paquete);
        //            }
        //        }

        //    }
        //    return View(paquete);

        //}

        //------------------------------------GetByid con WCF-----------------------------------------------------------------------------------------

        [HttpGet]
        //Esto es para el WebService
        public ActionResult Form(int? idPaquete)
        {
            //intancear el modelo de paquete
            ML.Paquete paquete = new ML.Paquete();
            //instancear la lista de paquetes (Trae sus propiedades)
            List<ML.Paquete> paqueteLis = new List<ML.Paquete>();

            if (idPaquete != null)
            {
                //para mandar llamar a lo registro para editar por el id

                ServiceReferencePaquete.IPaquetes client = new ServiceReferencePaquete.PaquetesClient();
                var resultado = client.GetById(idPaquete.Value);

                var resultadoPaquete = BL.Paquete.GetAllClient();
                paquete.paqueteLista = new List<ML.Paquete>();
                paqueteLis = resultadoPaquete.Item3;
                paquete.paqueteLista = paqueteLis;
                paquete.paqueteLista = resultadoPaquete.Item3;

                return View(paquete);

            }
            else
            {
                var resultado = BL.Paquete.GetAllClient();
                paquete.paqueteLista = new List<ML.Paquete>();
                paqueteLis = resultado.Item3;
                paquete.paqueteLista = paqueteLis;

                return View(paquete);



            }


        }



        //------------------------------------ADD y Update con webApi-----------------------------------------------------------------------------------------

        //[HttpPost]
        //public ActionResult Form(ML.Paquete paquete)

        //{
        //    //si es diferente de nulo el registro que enviare a editar que se cumpla la condicion para editarlo
        //    if (paquete.IdPaquete != 0)
        //    {
        //        //  variable donde se guardata el registro, luego llamar a mi gunvion editar de mi modelo y madarle mi parametro

        //        //var resultado = BL.Paquete.UpdateEF(paquete);

        //        //if (resultado.Item1)

        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("https://localhost:44327/api/");
        //            var responseTask = client.PutAsJsonAsync<ML.Paquete>("paquete/update", paquete);
        //            responseTask.Wait();

        //            var result = responseTask.Result;

        //            if (result.IsSuccessStatusCode)
        //            {

        //                ViewBag.Text = "La actualizacion fue Exitosa";
        //                return PartialView("Modal");
        //            }
        //            else
        //            {
        //                ViewBag.Text = "La actualizacion fracaso";
        //                return PartialView("Modal");
        //            }
        //        }

        //    }
        //    else
        //    {

        //        //var resultado = BL.Paquete.AddEF(paquete);

        //        //
        //        using (HttpClient client = new HttpClient())
        //        {
        //            ////URL - ENDPOINT
        //            client.BaseAddress = new Uri("https://localhost:44327/api/");
        //            var responseTask = client.PostAsJsonAsync<ML.Paquete>("paquete/Add", paquete);
        //            responseTask.Wait();

        //            var result = responseTask.Result;

        //            if (result.IsSuccessStatusCode)
        //            {


        //                ViewBag.Text = "Agregado Exitosamente";
        //                return PartialView("Modal");
        //            }
        //            else
        //            {
        //                ViewBag.Text = "Ha ocurrido un error";
        //                return PartialView("Modal");
        //            }

        //            //
        //            //if (resultado.Item1)
        //            //{

        //            //}
        //            //else
        //            //{
        //            //    ViewBag.Text = "Ha ocurrido un error";
        //            //    return PartialView("Modal");
        //        }


        //    }

        //}


        //------------------------------------ADD y Update con WFC-----------------------------------------------------------------------------------------

        [HttpPost]
        public ActionResult Form(ML.Paquete paquete)
        {
            // Verifica si el paquete es nuevo
            bool esNuevoPaquete = paquete.IdPaquete == 0;

            // Si es un nuevo paquete, agrega el paquete a la base de datos
            if (esNuevoPaquete)
            {
                // Agrega el paquete a la base de datos
                ServiceReferencePaquete.PaquetesClient client = new ServiceReferencePaquete.PaquetesClient();
                var result = client.Add(paquete);

                // Verifica si se pudo agregar correctamente
                if (result.Item1 != null)
                {
                    // Obtiene el último paquete agregado
                    var ultimoPaqueteResult = BL.Paquete.GetUltimoPaquete();

                    if (ultimoPaqueteResult.Item1)
                    {
                        var paqueteAgregado = ultimoPaqueteResult.Item3;

                        // Genera el contenido para el código QR utilizando los datos del paquete recién agregado
                        string contenidoQR = $"Número de guía: {paqueteAgregado.NumeroGuia}\n" +
                                             $"Instrucción de entrega: {paqueteAgregado.InstruccionEntrega}\n" +
                                             $"Peso: {paqueteAgregado.Peso} kg\n" +
                                             $"Origen: {paqueteAgregado.DireccionOrigen}\n" +
                                             $"Destino: {paqueteAgregado.DireccionEntrega}\n" +
                                             $"Fecha estimada de entrega: {paqueteAgregado.FechaEstimadaEntrega.ToString("yyyy-MM-dd")}";

                        // Genera un nombre único para el archivo del código QR utilizando la hora actual
                        string nombreArchivoQR = $"QR{DateTime.Now.ToString("yyyyMMddHHmmss")}.png";

                        // Ruta donde guardarás el archivo del código QR
                        string rutaGuardarQR = $@"C:\Users\digis\Documents\Hector Antonio Canales Mejia\HCanalesProgramacionCapas\PL_MVC\Imagen\CodigosQr\{nombreArchivoQR}";

                        // Genera el código QR y guárdalo en la ruta especificada
                        GenerarCodigoQR(contenidoQR, rutaGuardarQR);

                        // Actualiza la propiedad del paquete con la ruta del archivo del código QR
                        paqueteAgregado.CodigoQR = nombreArchivoQR;

                        // Actualiza el paquete en la base de datos con la ruta del código QR
                        client.UpdateEF(paqueteAgregado);

                        ViewBag.Text = "Paquete agregado exitosamente";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Text = ultimoPaqueteResult.Item2;
                        return PartialView("Modal");
                    }
                }
                else
                {
                    ViewBag.Text = "Fallo al agregar el paquete";
                    return PartialView("Modal");
                }
            }
            // Si es una actualización, realiza la actualización en la base de datos
            else
            {
                var resultado = BL.Paquete.UpdateEF(paquete);

                if (resultado.Item1)
                {
                    ServiceReferencePaquete.PaquetesClient client = new ServiceReferencePaquete.PaquetesClient();
                    var result = client.UpdateEF(paquete);

                    ViewBag.Text = "La actualización fue exitosa";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Text = "La actualización fracasó";
                    return PartialView("Modal");
                }
            }
        }



        //------------------------------------Delete -----------------------------------------------------------------------------------------


        //public ActionResult Delete(int? idPaquete)
        //{


        //    var resultdelete = BL.Paquete.DeleteLINQ(idPaquete.Value);


        //    if (resultdelete.Item1)
        //    {
        //        ViewBag.Text = "se ha eliminado correctamente";
        //        return PartialView("Modal");
        //    }
        //    else
        //    {
        //        ViewBag.Text = "NO se se ha eliminado correctamente";
        //        return PartialView("Modal");

        //    }


        //}

        //----------------------webapi-------------------------------------
        //Este es con web api (WebService)
        //public ActionResult Delete(int? idPaquete)
        //{

        //    //var resultdelete = BL.Paquete.DeleteLINQ(idPaquete.Value);
        //    //if (resultdelete.Item1)


        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44327/api/");
        //        var responseTask = client.DeleteAsync("paquete/Delete?IdPaquete= " + idPaquete);
        //        responseTask.Wait();

        //        var result = responseTask.Result;

        //        if (result.IsSuccessStatusCode)
        //        {

        //                ViewBag.Text = "se ha eliminado correctamente";
        //                return PartialView("Modal");
        //            }
        //    else
        //            {
        //                ViewBag.Text = "NO se se ha eliminado correctamente";
        //                return PartialView("Modal");

        //            }

        //    }

        //}



        //----------------------Delete WCF-------------------------------------

        public ActionResult Delete(int? idPaquete)
        {

            
                ServiceReferencePaquete.PaquetesClient client = new ServiceReferencePaquete.PaquetesClient();

                var resultado = client.DeleteLINQ(idPaquete.Value);
                if (resultado.Item1)
                {
                    ViewBag.Text = "se ha eliminado correctamente";
                    return PartialView("Modal");

                }
                else
                {
                    ViewBag.Text = "NO se se ha eliminado correctamente";
                    return PartialView("Modal");
                }
                
            
            
        }



        // Método para generar el código QR y guardarlo en un archivo
        public void GenerarCodigoQR(string contenido, string rutaGuardar)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20); // 20 es el tamaño de los módulos en píxeles

            qrCodeImage.Save(rutaGuardar); // Guarda la imagen del código QR en la ruta especificada
        }


    }
}
