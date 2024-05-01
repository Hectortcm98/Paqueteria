
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class TransporteController : Controller
    {
        // GET: Transporte
        public ActionResult GetAllTransporte()
        {
            var result = BL.Transporte.GetAllLINQ();
            if (result.Item1 == true)
            {
                ML.Transporte transporte = result.Item3;

                return View(transporte);

            }
            else
            {
                ML.Transporte transporte = new ML.Transporte();
                return View();
            }
        }


        [HttpGet]
        public ActionResult Form(int? idTransporte)
        {
            //Instanciando del objeto  de ML.Transporte
            ML.Transporte transporte = new ML.Transporte();

            //intancia de un objeto  de tipo lista  de ML.Roll (trae propiedades)
            List<ML.EstatusTransporte> estatusLista = new List<ML.EstatusTransporte>();

            if (idTransporte != null)
            {
             //para madar llamar a lo registro para editar 
                var resulEstatus = BL.Transporte.GetByIdEF(idTransporte.Value); //getallEstatus
                transporte = resulEstatus.Item3;

                var resutadoEstatus = BL.EstatusTransporte.GetAllEstatus();
                transporte.estatusTransporte = new ML.EstatusTransporte();//instancia
                estatusLista = resutadoEstatus.Item3;
                transporte.estatusTransporte.EstatusLista = estatusLista;
                transporte.estatusTransporte.EstatusLista = resutadoEstatus.Item3;
                //para madar llamar a lo registro para editar 


                return View(transporte);
            }
            else
            {
                //para madar llamar a lo registro para editar 
                var resulEstatus = BL.EstatusTransporte.GetAllEstatus();
                transporte.estatusTransporte = new ML.EstatusTransporte();
                estatusLista = resulEstatus.Item3;
                transporte.estatusTransporte.EstatusLista = estatusLista;


                return View(transporte);
                //para madar llamar a lo registro para editar 
            }

        }


        [HttpPost]
        public ActionResult Form(ML.Transporte transporte)

        {

           
            ////Intarciar
            //ML.Direccion direccion = new ML.Direccion();
            //AEditar al fromulrio
            if (transporte.IdTransporte != 0)
            {

                var updateResult = BL.Transporte.UpdateEF(transporte);

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

                var result = BL.Transporte.Add(transporte);
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
        public ActionResult Delete(int? idTransporte)
        {
            ML.Transporte transporte = new ML.Transporte();
            transporte.IdTransporte = idTransporte.Value;
            
            var resultdelete = BL.Transporte.DeleteEF(transporte);
            

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
