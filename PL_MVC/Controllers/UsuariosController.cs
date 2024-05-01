using BL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace PL_MVC.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        [HttpGet]
        public ActionResult GetAllEF()
        {        
            ML.Usuario usuarioBusqueda = new ML.Usuario();
          
            usuarioBusqueda.Nombre = "";
            usuarioBusqueda.ApellidoPaterno = "";
            usuarioBusqueda.ApellidoMaterno = "";

            var result = BL.Usuario.GetAllEF(usuarioBusqueda);
            
            if (result.Item1) 
            {
                
                ML.Usuario usuario = result.Item3;               
                return View(usuario);
            }
            else
            {
                //List<ML.Usuario> usuarioLista = new List<ML.Usuario>();
                ML.Usuario usuario = new ML.Usuario();
                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult GetAllEF(ML.Usuario usuarioBusqueda)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuarioBusqueda.Nombre = (usuarioBusqueda.Nombre == null) ? usuarioBusqueda.Nombre = "" : usuarioBusqueda.Nombre;
            usuarioBusqueda.ApellidoPaterno = (usuarioBusqueda.ApellidoPaterno == null) ? usuarioBusqueda.ApellidoPaterno = "" : usuarioBusqueda.ApellidoPaterno;
            usuarioBusqueda.ApellidoMaterno = (usuarioBusqueda.ApellidoMaterno == null) ? usuarioBusqueda.ApellidoMaterno = "" : usuarioBusqueda.ApellidoMaterno;

            var result = BL.Usuario.GetAllEF(usuarioBusqueda);
            
            if (result.Item1)
            {
                usuario = result.Item3;
                return View(usuario);
            }
            else
            {
                usuario = new ML.Usuario();
                return View(usuario);
            }

            
            
        }


        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            //Instanciando del objeto  de ML.Usuario
            ML.Usuario usuario = new ML.Usuario();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();

            //Navegacion paises 
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            usuario.Roll = new ML.Roll();
            var listaroles = BL.Roll.GetAllRollEF();
            List<ML.Roll> rolLista = new List<ML.Roll>();
            var roles = listaroles.Item3;

            var listPaises = BL.Pais.GetAll();
            var paises = listPaises.Item3;

            //intancia de un objeto  de tipo lista  de ML.Roll (trae propiedades)
            

            

            if (idUsuario != null)
            {
                var resulRolles = BL.Roll.GetAllRollEF();
                
                var resultado = BL.Usuario.GetByIdEF(idUsuario.Value);
                usuario = resultado.Item3;

                //propiedades de DropDownList
                //getallRoll
                usuario.Roll = new ML.Roll();           //instancia
                rolLista = resulRolles.Item3;
                usuario.Roll.RolLista = rolLista;
                usuario.Roll.RolLista = resulRolles.Item3;
                
                
                //pais // esto es para el update 
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = paises;
                usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.Id_Municipio).Item3;
                usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.Id_Estado).Item3;
                usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.Id_Pais).Item3;

                return View(usuario);//al final le paso el usuario  a la vista con el objeto usuario
                                     //var  rolles = BL.Roll.GetAllRollEF(); //getallRoll
                                     //usuario.Roll.Rolles = rolles.Item3.Rolles; // Propiedad de navegacion
            }
            else
            {

                var resulRolles = BL.Roll.GetAllRollEF();
                usuario.Roll = new ML.Roll();
                rolLista = resulRolles.Item3;
                usuario.Roll.RolLista = rolLista;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = paises;

                return View(usuario);
            }

        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)

        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Imagen"];

                if (file.ContentLength > 0)
                {
                    usuario.Imagen = ConvertirABase64(file);
                }
            
           
            }
            else
            {
                //esto si en caso no es valido
                var roles = BL.Roll.GetAllRollEF();
                var pais = BL.Pais.GetAll();
                var estado = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.Id_Pais);
                var municipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.Id_Estado);
                var colonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.Id_Municipio);

               
                usuario.Roll.RolLista = roles.Item3;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = pais.Item3;
                usuario.Direccion.Colonia.Municipio.Estado.Estados = estado.Item3;
                usuario.Direccion.Colonia.Municipio.Municipios = municipio.Item3;
                usuario.Direccion.Colonia.Colonias = colonia.Item3;


                return View(usuario);

            }

           
            


            if (usuario.IdUsuario != 0)
            {

                var updateResult = BL.Usuario.UpdateEF(usuario);

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

                var result = BL.Usuario.AddEF(usuario);
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

            /*
                    // GET: Usuarios/Details/5
                    public ActionResult Details(int id)
                    {
                        return View();
                    }

                    // GET: Usuarios/Create
                    public ActionResult Create()
                    {
                        return View();
                    }

                    // POST: Usuarios/Create
                    [HttpPost]
                    public ActionResult Create(FormCollection collection)
                    {
                        try
                        {
                            // TODO: Add insert logic here

                            return RedirectToAction("Index");
                        }
                        catch
                        {
                            return View();
                        }
                    }

                    // GET: Usuarios/Edit/5
                    public ActionResult Edit(int id)
                    {
                        return View();
                    }

                    // POST: Usuarios/Edit/5
                    [HttpPost]
                    public ActionResult Edit(int id, FormCollection collection)
                    {
                        try
                        {
                            // TODO: Add update logic here

                            return RedirectToAction("Index");
                        }
                        catch
                        {
                            return View();
                        }
                    }

                    // GET: Usuarios/Delete/5
                    public ActionResult Delete(int id)
                    {
                        return View();
                    }

                    // POST: Usuarios/Delete/5
                    [HttpPost]
                    public ActionResult Delete(int id, FormCollection collection)
                    {
                        try
                        {
                            // TODO: Add delete logic here

                            return RedirectToAction("Index");
                        }
                        catch
                        {
                            return View();
                        }
                    }*/
        }

    
    [HttpGet]
    public ActionResult Delete(int? idUsuario)
    {
        ML.Usuario usuario = new ML.Usuario();
        usuario.IdUsuario = idUsuario.Value;

        var resultdelete = BL.Usuario.DeleteEF( usuario);

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


        //Metodo para el  GetById del Pais
        [HttpPost]
        public JsonResult  EstadoGetByIdPais (int Id_Pais)
        {

            var result = BL.Estado.GetByIdPais(Id_Pais);
            if (result.Item1)
            {
                return Json(result.Item3, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }

        }

        //Metodo para el  GetById del Pais
        [HttpPost]
        public JsonResult MunicipioGetByIdEstado(int Id_Estado)
        {
            var result = BL.Municipio.GetByIdEstado(Id_Estado);
            if (result.Item1)
            {
                return Json(result.Item3, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult ColoniaGetByIdMunicipio(int Id_Municipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(Id_Municipio);
            if (result.Item1)
            {
                return Json(result.Item3, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Logout()
        {
            // Aquí puedes realizar cualquier lógica necesaria para cerrar la sesión del usuario,
            // como limpiar las cookies de autenticación, borrar la sesión de usuario, etc.

            // Por ejemplo, en ASP.NET Core, puedes usar HttpContext.SignOutAsync();
            // En ASP.NET MVC, puedes limpiar las cookies de autenticación así:
            FormsAuthentication.SignOut();

            // Después de cerrar la sesión, redirige al usuario a la página de inicio
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            if (Foto == null || Foto.ContentLength == 0)
            {
                // Si la imagen es nula o no tiene contenido, devuelve una cadena vacía
                return string.Empty;
            }

            try
            {
                using (System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream))
                {
                    byte[] data = reader.ReadBytes((int)Foto.ContentLength);
                    string imagenBase64 = Convert.ToBase64String(data);
                    return imagenBase64;
                }
            }
            catch (Exception ex)
            {
                
                return string.Empty;
            }
        }


        [HttpPost]
        public JsonResult CambiarEstatus(int IdUsuario, bool Estatus)
        {
            var result = BL.Usuario.CambioEstatus(IdUsuario, Estatus);
            if (result.Item1)
            {
                return Json(result.Item1, JsonRequestBehavior.AllowGet);
            }
            else 
            { 
                return Json(result.Item2, JsonRequestBehavior.AllowGet); 
            }
        }


        public ActionResult CerrarSesion()
        {
            Session.Clear(); // Cierra la sesión del usuario
            return RedirectToAction("Login", "Login"); // Redirige al usuario a la página de inicio u otra página deseada
        }
    }

}
