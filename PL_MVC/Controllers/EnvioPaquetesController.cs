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
                ML.Asignar asignar = new ML.Asignar();
                asignar.Asignacion = new List<ML.Asignar>();

                return View(asignar);
            }
            else
            {
                ML.Asignar asignar = new ML.Asignar();
                asignar.Asignacion = new List<ML.Asignar>();
                asignar.Asignacion = (List<ML.Asignar>)Session["Asignar"];
                return View(asignar);
            }
        }

        [HttpPost]
        public ActionResult AddToSession(ML.Asignar asignarAdd)
        {


            if (asignarAdd.Repartidor == null || asignarAdd.Repartidor.IdRepartidor == 0)
            {
                ViewBag.Text = "Es necesario elegir un repartidor";
                return PartialView("Modal");
            }

            bool exists = false;

                ML.Asignar asignar = new ML.Asignar();
                asignar.Asignacion = new List<ML.Asignar>();
                asignar.Paquete = new ML.Paquete();
                asignar.Repartidor = new ML.Repartidor();


                var result = BL.Paquete.GetByIdLINQ(asignarAdd.Paquete.IdPaquete);
                var resultRepatidor = BL.Repartidor.GetById(asignarAdd.Repartidor.IdRepartidor);


                asignar.Paquete = result.Item3;
                asignar.Repartidor = resultRepatidor.Item3;
                if (Session["Asignar"] == null)
                {
                    asignar.TotalPaquetes = 1;
                    asignar.Asignacion.Add(asignar);

                    Session["Asignar"] = asignar.Asignacion;


                }
                else
                {
                    GetAsignar(asignar);
                    foreach (ML.Asignar paquete in asignar.Asignacion)
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
                        Session["Asignar"] = asignar.Asignacion;
                    }
                    else
                    {
                        asignar.TotalPaquetes = 1;
                        asignar.Asignacion.Add(asignar);
                        Session["Asignar"] = asignar.Asignacion;
                    }
                }      

            ViewBag.Text = "Asignacion correcta";
            return PartialView("Modal");
            //return RedirectToAction("GetAll", "Paquete");
        }

          
        public ML.Asignar GetAsignar(ML.Asignar asignar)
        {
            List<ML.Asignar> asignacion = (List<ML.Asignar>)Session["Asignar"];

            foreach(var obj in asignacion)
            {
                asignar.Asignacion.Add(obj);
            }
            return asignar;
        }


        

        [HttpPost]
        public ActionResult IncremetarPaquetes(int repartidorId)
        {
            var asignacion = (List<ML.Asignar>)Session["Asignar"];
            if (asignacion != null)
            {
                // Encuentra la asignación correspondiente al repartidorId y aumenta la cantidad de paquetes
                var asignar = asignacion.FirstOrDefault(a => a.Repartidor.IdRepartidor == repartidorId);
                if (asignar != null)
                {
                    asignar.TotalPaquetes++;
                }
                Session["Asignar"] = asignacion;
            }

            // indicador de éxito 
            return Json(new { success = true });
        }



        [HttpPost]
        public ActionResult DisminuirPaquetes(int repartidorId)
        {
            var asignacion = (List<ML.Asignar>)Session["Asignar"];
            if (asignacion != null)
            {
                // Encuentra la asignación correspondiente al repartidorId y disminuye la cantidad de paquetes
                var asignar = asignacion.FirstOrDefault(a => a.Repartidor.IdRepartidor == repartidorId);

                if (asignar != null)
                {
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
