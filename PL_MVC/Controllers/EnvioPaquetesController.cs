using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EnvioPaquetesController : Controller
    {
        public ActionResult EnviarPaquetes()
        {
            if (Session["Asignar"] == null)
            {
                ML.AsignacionPaqueteRepartidor asignar = new ML.AsignacionPaqueteRepartidor();
                asignar.Asignaciones = new List<ML.AsignacionPaqueteRepartidor>();

                return View(asignar);
            }
            else
            {
                ML.AsignacionPaqueteRepartidor asignar = new ML.AsignacionPaqueteRepartidor();
                asignar.Asignaciones = new List<ML.AsignacionPaqueteRepartidor>();
                asignar.Asignaciones = (List<ML.AsignacionPaqueteRepartidor>)Session["Asignar"];
                return View(asignar);
            }
        }

        [HttpPost]
        public ActionResult AddToSession(ML.AsignacionPaqueteRepartidor asignarAdd)
        {


            if (asignarAdd.Repartidor == null || asignarAdd.Repartidor.IdRepartidor == 0)
            {
                ViewBag.Text = "Es necesario elegir un repartidor";
                return PartialView("Modal");
            }

            bool exists = false;

                ML.AsignacionPaqueteRepartidor asignar = new ML.AsignacionPaqueteRepartidor();
                asignar.Asignaciones = new List<ML.AsignacionPaqueteRepartidor>();
                asignar.Paquete = new ML.Paquete();
                asignar.Repartidor = new ML.Repartidor();


                var result = BL.Paquete.GetByIdLINQ(asignarAdd.Paquete.IdPaquete);
                var resultRepatidor = BL.Repartidor.GetById(asignarAdd.Repartidor.IdRepartidor);


                asignar.Paquete = result.Item3;
                asignar.Repartidor = resultRepatidor.Item3;
                BL.AsignacionPaqueteRepartidor.AddEF(asignarAdd.Paquete.IdPaquete, asignarAdd.Repartidor.IdRepartidor);
                if (Session["Asignar"] == null)
                {
                    asignar.TotalPaquetes = 1;
                    asignar.Asignaciones.Add(asignar);

                    Session["Asignar"] = asignar.Asignaciones;
                    //BL.AsignacionPaqueteRepartidor.AddEF(asignarAdd.Repartidor.IdRepartidor, asignarAdd.Paquete.IdPaquete);

                }
                else
                {
                    GetAsignar(asignar);
                    foreach (ML.AsignacionPaqueteRepartidor paquete in asignar.Asignaciones)
                    {
                        if (asignarAdd.Repartidor.IdRepartidor == paquete.Repartidor.IdRepartidor)
                        {
                            paquete.TotalPaquetes++;
                            exists = true;
                            break;
                        }
                        else
                        {
                            exists = false;
                        }
                    }
                    if (exists)
                    {
                        Session["Asignar"] = asignar.Asignaciones;
                    }
                    else
                    {
                        asignar.TotalPaquetes = 1;
                        asignar.Asignaciones.Add(asignar);
                        Session["Asignar"] = asignar.Asignaciones;
                    }
                }      

            ViewBag.Text = "Asignacion correcta";
            return PartialView("Modal");
            //return RedirectToAction("GetAll", "Paquete");
        }

          
        public ML.AsignacionPaqueteRepartidor GetAsignar(ML.AsignacionPaqueteRepartidor asignar)
        {
            List<ML.AsignacionPaqueteRepartidor> asignacion = (List<ML.AsignacionPaqueteRepartidor>)Session["Asignar"];

            foreach(var obj in asignacion)
            {
                asignar.Asignaciones.Add(obj);
            }
            return asignar;
        }



        [HttpPost]
        public ActionResult IncremetarPaquetes(int repartidorId)
        {
            var asignacion = (List<ML.AsignacionPaqueteRepartidor>)Session["Asignar"];
            if (asignacion != null)
            {
                // Encuentra la asignación correspondiente al repartidorId
                var asignar = asignacion.FirstOrDefault(a => a.Repartidor.IdRepartidor == repartidorId);
                if (asignar != null)
                {
                    // Aumenta la cantidad de paquetes asignados al repartidor en la base de datos
                    var result = BL.AsignacionPaqueteRepartidor.ModificarCatidad(repartidorId, 1);
                    if (result.Item1)
                    {
                        // Si la operación en la base de datos es exitosa, aumenta la cantidad de paquetes en la sesión
                        asignar.TotalPaquetes++;
                        Session["Asignar"] = asignacion;

                        // Redirige a una vista de éxito
                        ViewBag.Text = "Asignacion correcta";
                        return PartialView("Modal");
                    }
                    else
                    {
                        // Si la operación en la base de datos falla, redirige a una vista de error
                        return View("Error");
                    }
                }
            }

            // Si no se encuentra la asignación, o no hay asignaciones en la sesión, redirige a una vista de error
            return View("Error");
        }




        [HttpPost]
        public ActionResult DisminuirPaquetes(int repartidorId)
        {
            var asignacion = (List<ML.AsignacionPaqueteRepartidor>)Session["Asignar"];
            if (asignacion != null)
            {
                // Encuentra la asignación correspondiente al repartidorId y disminuye la cantidad de paquetes
                var asignar = asignacion.FirstOrDefault(a => a.Repartidor.IdRepartidor == repartidorId);
                if (asignar != null)
                {
                    var result = BL.AsignacionPaqueteRepartidor.ModificarCatidad(repartidorId, -1);
                    asignar.TotalPaquetes--;

                    // Si la cantidad de paquetes llega a cero, se elimina la asignación de la lista
                    if (asignar.TotalPaquetes <= 0)
                    {
                        asignacion.Remove(asignar);
                    }
                }
                Session["Asignar"] = asignacion;
            }

            // retornar indicador de éxito 
            return Json(new { success = true });
        }


    }
}
