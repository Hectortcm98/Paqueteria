using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class RepartidorController : Controller
    {
        // GET: Repartidor
        public ActionResult GetAll()
        {
            var result = BL.Repartidor.GetAllEF();
            if (result.Item1 == true)
            {
                ML.Repartidor repartidor = result.Item3;

                return View(repartidor);

            }
            else
            {
                ML.Repartidor repartidor = new ML.Repartidor();
                return View();
            }
        }



        [HttpGet]
        public ActionResult Form(int? idRepartidor)
        {
            //Instanciando del objeto  de ML.Transporte
            ML.Repartidor repartidor = new ML.Repartidor();


            if (idRepartidor != null)
            {
                //para madar llamar a lo registro para editar 
                var resulEstatus = BL.Repartidor.GetById(idRepartidor.Value); //getallEstatus
                repartidor = resulEstatus.Item3;

                return View(repartidor);
            }
            else
            {
                //para madar llamar a lo registro para editar 
                var resulEstatus = BL.Repartidor.GetAllEF();
                repartidor.Repartidores = new ML.Repartidor().Repartidores;
                repartidor = resulEstatus.Item3;
                repartidor.Repartidores = repartidor.Repartidores;


                return View(repartidor);
                //para madar llamar a lo registro para editar 
            }

        }

        [HttpPost]
        public ActionResult Form(ML.Repartidor repartidor)
        {

            ////Intarciar
            //ML.Direccion direccion = new ML.Direccion();
            //AEditar al fromulrio
            if (repartidor.IdRepartidor != 0)
            {

                var updateResult = BL.Repartidor.UpdateEF(repartidor);

                if (updateResult.Item1) // Verificar si la actualización fue exitosa
                {
                    ViewBag.Text = "Se ha actualizado correctamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Text = "NO se ha podido actualizar correctamente";
                    return PartialView("Modal");
                }
            }
            else
            {
                var result = BL.Repartidor.AddEF(repartidor);
                if (result.Item1 == true)
                {
                    ViewBag.Text = "se ha agregado correctamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Text = "NO se ha agregado correctamente";
                    return PartialView("Modal");
                }
            }
        }


        [HttpGet]
        public ActionResult Delete(int? idRepartidor)
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            repartidor.IdRepartidor = idRepartidor.Value;

            var resultdelete = BL.Repartidor.DeleteEF(repartidor);
            if (resultdelete.Item1)
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
    }
}