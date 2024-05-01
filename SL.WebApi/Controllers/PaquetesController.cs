using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.WebApi.Controllers
{
    public class PaquetesController : ApiController
    {

        [HttpPost]
        [Route("api/paquete/Add")]
        public IHttpActionResult Add([FromBody]ML.Paquete paquete)
        {
            var result = BL.Paquete.AddEF(paquete);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }


        [HttpPut]
        [Route("api/paquete/Update")]
        public IHttpActionResult Update ([FromBody] ML.Paquete paquete)
        {
            var result = BL.Paquete.UpdateEF(paquete);
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [HttpGet]
        [Route("api/paquete/GetById")]
        public IHttpActionResult GetById (int IdPaquete) 
        {
            var result = BL.Paquete.GetByIdLINQ(IdPaquete);
            if(result.Item1)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else { return Content(HttpStatusCode.BadRequest, result);}
        }

        [HttpDelete]
        [Route("api/paquete/Delete")]
        public IHttpActionResult Delete (int IdPaquete)
        {
            var result = BL.Paquete.DeleteLINQ(IdPaquete);
            if (result.Item1) 
            { 
                return Content(HttpStatusCode.OK, result);
            }else 
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }


        [HttpGet]
        [Route("api/paquete/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.Paquete.GetAllClient();
            if (result.Item1)
            {
                return Content(HttpStatusCode.OK, result.Item3);
            }
            else { return Content(HttpStatusCode.BadRequest, result.Item3); }
        }


        //[HttpGet]
        //[Route("api/paquete/Add")]

    }
}
