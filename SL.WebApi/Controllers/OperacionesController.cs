using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.WebApi.Controllers
{
    public class OperacionesController : ApiController
    {
        [Route("api/Saludo")]
        [HttpPost]
        public IHttpActionResult Saludar(String Nombre) 
        { 
            String saludo ="Hola yo soy" + Nombre;

            //Tipo de retorno  JSON, HTTP status code 100,200,300,400 
            return Content (HttpStatusCode.OK, saludo);

        }
        [Route("api/Suma")]
        [HttpPost]
        public IHttpActionResult Suma( int N1  = 2 , int N2 = 3 )
        {
          
            String lasuma = "La suma es:  ";
            int suma =  N1 + N2;
           
            return Content (HttpStatusCode.OK, lasuma + suma );

        }

        [Route("api/Resta")]
        [HttpPost]
        public IHttpActionResult Resta(int N1 = 2, int N2 = 3)
        {

            String laResta = "La resta de 2 - 3  es :  ";
            int suma = N1 - N2;

            return Content(HttpStatusCode.OK, laResta + suma);

        }

        [Route("api/Mutiplicacion")]
        [HttpPost]
        public IHttpActionResult Mutiplicacion(int N1 = 2, int N2 = 3)
        {

            String laMult = "La Mutiplicacion de 2 * 3 es:  ";
            int suma = N1 + N2;

            return Content(HttpStatusCode.OK, laMult + suma);

        }

        [Route("api/Division")]
        [HttpPost]
        public IHttpActionResult Division(int N1 = 8, int N2 = 4)
        {

            String laDiv = "La Divisionde de 2 / 3  es:  ";
            int suma = N1 / N2;

            return Content(HttpStatusCode.OK, laDiv + suma);

        }


        //[Route("api/Suma")]
        //[HttpPost]
        //public IHttpActionResult Suma(int N1 = 2, int N2 = 3)
        //{


        //    int suma = N1 + N2;
        //    return Content(HttpStatusCode.OK, suma);

        //}
    }
}
