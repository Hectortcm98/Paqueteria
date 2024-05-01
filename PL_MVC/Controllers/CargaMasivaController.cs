using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        public ActionResult Get()
        {

            ML.ResultExcel resultExcel = new ML.ResultExcel();

            return View(resultExcel);

        }


        [HttpPost]
        public ActionResult Get(int? dato)
        {


            // Validar la extensión del archivo
            if (Session["PathArchivo"] == null)
            {
                HttpPostedFileBase file = Request.Files["ArchivoExcel"];
                string pathFolder = ConfigurationManager.AppSettings["pathFolder"].ToString();

                if (file.ContentLength > 0)
                {
                    string extensionArchivo = Path.GetExtension(file.FileName).ToLower();
                    string extensionModulo = ConfigurationManager.AppSettings["TipoExcel"].ToString();

                    if (extensionArchivo == extensionModulo)
                    {
                        string pathArchivo = Server.MapPath(pathFolder) + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                        if (!System.IO.File.Exists(pathArchivo))
                        {
                            file.SaveAs(pathArchivo);
                            string connectionString = ConfigurationManager.AppSettings["ConnectionStringExcel"].ToString() + pathArchivo;
                            var resultPaquetes = BL.Paquete.CargaMasivaExcel(connectionString);

                            if (resultPaquetes.Item1)
                            {
                                // Aquí obtienes los paquetes
                                var result =  resultPaquetes.Item3;
                                // Asegúrate de que los paquetes sean válidos antes de pasarlos a la vista
                                if (result != null && result.Any())
                                {
                                    // Si los paquetes son válidos, puedes guardar la ruta del archivo en la sesión
                                    Session["PathArchivo"] = pathArchivo;
                                    // Y luego pasas los paquetes a la vista
                                    return View(new ML.ResultExcel() { Paquetes = result });
                                }
                                else
                                {
                                    ViewBag.Text = "El archivo no contiene paquetes válidos.";
                                    return PartialView("Modal");
                                }
                            }
                            else
                            {
                                //ViewBag.Text = "El excel no contiene registros en las Fila ni Columna";
                                //return PartialView("Modal");
                                return View(new ML.ResultExcel());
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Text = "Favor de seleccionar un archivo .xlsx, Verifique su archivo";
                        return PartialView("Modal");
                    }
                }
                else
                {
                    ViewBag.Mensaje = "No selecciono ningun archivo, Seleccione uno correctamente";
                }
                return View();
            }
            else
            {
                // Si la sesión existe, se omite la validación y se agregan los paquetes a la base de datos
                string pathArchivo = Session["PathArchivo"].ToString();
                string connectionString = ConfigurationManager.AppSettings["ConnectionStringExcel"].ToString() + pathArchivo;

                // Proceso de lectura del archivo Excel y obtención de los datos
                var datos = BL.Paquete.CargaMasivaExcel(connectionString);

                if (datos.Item1)
                {
                    // Si se cargaron los datos exitosamente del archivo Excel
                    foreach (ML.Paquete paquete in datos.Item3)
                    {
                        // Agregar cada paquete a la base de datos
                        BL.Paquete.AddEF(paquete);
                    }

                    // Limpiar la sesión
                    Session["PathArchivo"] = null;

                    // Mostrar mensaje de éxito

                    //ViewBag.Text = "Exitoso";
                    //return PartialView("Modal");
                    return View(new ML.ResultExcel());
                }
                else
                {
                    // Si hubo algún problema al cargar los datos del archivo Excel
                    //ViewBag.Text = "Hubo un error al cargar los paquetes desde el archivo Excel.";
                    //return PartialView("Modal");
                    return View(new ML.ResultExcel());
                }
            }
        }

    }
}






        //[HttpPost]
        //public ActionResult CargaTXT()
        //{
        //    HttpPostedFileBase file = Request.Files["ArchivoTXT"];

        //    if (file != null)
        //    {
        //        if (file.ContentLength > 0)
        //        {
        //            string extension = Path.GetExtension(file.FileName).ToLower();

        //            if (extension == ".txt")
        //            {
        //                string pathFolder = "~/CargaMasiva/";
        //                string pathArchivo = Server.MapPath(pathFolder) + Path.GetFileNameWithoutExtension(file.FileName) + "-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";

        //                if (!System.IO.File.Exists(pathArchivo))
        //                {
        //                    file.SaveAs(pathArchivo);



        //                    return PartialView("Modal");
        //                }
        //            }
        //        }
        //    }

        //    return View();
        //}

    
