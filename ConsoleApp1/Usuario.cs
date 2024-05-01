using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Usuario
    // Propiedades --> Métodos
    {

        //pedir la informacion 
        /*  public static void Add()
          {
              ML.Usuario usuario = new ML.Usuario();
              Console.WriteLine("Ingresa el Nombre del Usuario");
              usuario.Nombre = Console.ReadLine();

              Console.WriteLine("Ingresa la Apellido Paterno del Usuario");
              usuario.ApellidoPaterno = Console.ReadLine();

              Console.WriteLine("Ingresa la Apellido Materno del Usuario");
              usuario.ApellidoMaterno = Console.ReadLine();

              Console.WriteLine("Ingresa el UserName del Usuario");
              usuario.UserName = Console.ReadLine();

              Console.WriteLine("Ingresa el Email del Usuario");
              usuario.Email = Console.ReadLine();

              Console.WriteLine("Ingresa el Password del Usuario");
              usuario.Password = Console.ReadLine();

              Console.WriteLine("Ingresa La Fecha de Nacimiento del Usuario");
              usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

              Console.WriteLine("Ingresa el Sexo del Usuario");
              usuario.Sexo = Console.ReadLine();

              Console.WriteLine("Ingresa el Telefono del Usuario");
              usuario.Telefono = Console.ReadLine();

              Console.WriteLine("Ingresa el Celular del Usuario");
              usuario.Celular= Console.ReadLine();

              Console.WriteLine("Ingresa La CURP del Usuario");
              usuario.CURP = Console.ReadLine();


              bool resultado = BL.Usuario.AddEF(usuario);

              // bool resultado = BL.Usuario.Add(usuario);
              //bool resultado = BL.Usuario.AddSP(usuario);  //llamamos al stored Prodedure

              if (resultado)
              {
                  Console.WriteLine("Se ha insertado un registro");
              }
              else
              {
                  Console.WriteLine("NO se ha insertado un registro");
              }
              Console.ReadKey();
          }*/
        /*  public static void Update(int IdUsuario)
          {
              ML.Usuario usuario = new ML.Usuario();
              usuario.IdUsuario = IdUsuario;

              Console.WriteLine("Ingresa el Nombre del Usuario");
              usuario.Nombre = Console.ReadLine();

              Console.WriteLine("Ingresa la Apellido Paterno del Usuario");
              usuario.ApellidoPaterno = Console.ReadLine();

              Console.WriteLine("Ingresa la Apellido Materno del Usuario");
              usuario.ApellidoMaterno = Console.ReadLine();

              Console.WriteLine("Ingresa el UserName del Usuario");
              usuario.UserName = Console.ReadLine();

              Console.WriteLine("Ingresa el Email del Usuario");
              usuario.Email = Console.ReadLine();

              Console.WriteLine("Ingresa el Password del Usuario");
              usuario.Password = Console.ReadLine();

              Console.WriteLine("Ingresa La Fecha de Nacimiento del Usuario");
              usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

              Console.WriteLine("Ingresa el Sexo del Usuario");
              usuario.Sexo = Console.ReadLine();

              Console.WriteLine("Ingresa el Telefono del Usuario");
              usuario.Telefono = Console.ReadLine();

              Console.WriteLine("Ingresa el Celular del Usuario");
              usuario.Celular = Console.ReadLine();

              Console.WriteLine("Ingresa La CURP del Usuario");
              usuario.CURP = Console.ReadLine();


              var resultado = BL.Usuario.UpdateEF(usuario);

              if (resultado)
              {
                  Console.WriteLine("El registro se ha actualizado exitosamente");
              }
              else 
              {
                  Console.WriteLine("El registro no se ha actualizado exitosamente");
              }
              Console.ReadKey();
          }*/
        // Insertar informacion 

        /* public static void GetALL()
          {

              List<ML.Usuario> usuarios = BL.Usuario.GetAllEF();


              if (usuarios.Count > 0)
              {
                  Console.WriteLine("Tabla exitosa");

                  foreach (var usuario in usuarios)
                  {
                      Console.WriteLine($"IdUsuario: {usuario.IdUsuario}");
                      Console.WriteLine($"Nombre: {usuario.Nombre}");
                      Console.WriteLine($"ApellidoPaterno: {usuario.ApellidoPaterno}");
                      Console.WriteLine($"ApellidoMaterno: {usuario.ApellidoMaterno}");
                      Console.WriteLine($"UserName: {usuario.UserName}");
                      Console.WriteLine($"Email: {usuario.Email}");
                      Console.WriteLine($"Password: {usuario.Password}");
                      Console.WriteLine($"FechaNacimiento: {usuario.FechaNacimiento}");
                      Console.WriteLine($"Sexo: {usuario.Sexo}");
                      Console.WriteLine($"Telefono: {usuario.Telefono}");
                      Console.WriteLine($"Celular: {usuario.Celular}");
                      Console.WriteLine($"CURP: {usuario.CURP}");
                      Console.WriteLine("--------------------------------");


                  }
              }
              else
              {
                  Console.WriteLine("La Tabla esta vacia");
              }
          }*/
        /* public static void Update()
         {
             ML.Usuario usuario = new ML.Usuario();

             Console.WriteLine("Ingresa el IdUsuario que deseas actualizar");
             usuario.IdUsuario = int.Parse(Console.ReadLine());

             Console.WriteLine("Ingresa el nuevo  Nombre del Usuario");
             usuario.Nombre = Console.ReadLine();

             Console.WriteLine("Ingresa el nuevo  Apellido Paterno del Usuario");
             usuario.ApellidoPaterno = Console.ReadLine();

             Console.WriteLine("Ingresa el Apellido Materno del Usuario");
             usuario.ApellidoMaterno = Console.ReadLine();

             Console.WriteLine("Ingresa el Apellido Email del Usuario");
             usuario.ApellidoMaterno = Console.ReadLine();

             Console.WriteLine("Ingresa el Apellido Password del Usuario");
             usuario.ApellidoMaterno = Console.ReadLine();

             Console.WriteLine("Ingresa el Apellido Fecha de nacimiento del Usuario");
             usuario.ApellidoMaterno = Console.ReadLine();

             Console.WriteLine("Ingresa el Apellido Sexo del Usuario");
             usuario.ApellidoMaterno = Console.ReadLine();

             Console.WriteLine("Ingresa el Apellido Telefono del Usuario");
             usuario.ApellidoMaterno = Console.ReadLine();

             Console.WriteLine("Ingresa el Apellido Celular del Usuario");
             usuario.ApellidoMaterno = Console.ReadLine();

             Console.WriteLine("Ingresa el Apellido CURP del Usuario");
             usuario.ApellidoMaterno = Console.ReadLine();

             Console.WriteLine("Ingresa el Apellido Imagen del Usuario");
             usuario.ApellidoMaterno = Console.ReadLine();

             bool resultado = BL.Usuario.Update(usuario);
             //bool resultado = BL.Usuario.UpdateSP(usuario);
             if (resultado)
             {
                 Console.WriteLine("Se ha actualizado  el registro correctamente");
             }
             else
             {
                 Console.WriteLine("No se ha actualizado  el registro correctamente");
             }
             Console.ReadKey();



         }*

       /*  public static void Delete()

         {
             ML.Usuario usuario = new ML.Usuario();

             Console.WriteLine("Ingresa el ID del usuario que deseas Eleminar");
             usuario.IdUsuario = int.Parse(Console.ReadLine());

              bool resultado = BL.Usuario.Delete(usuario);
            // bool resultado = BL.Usuario.DeleteSP(usuario);
             if (resultado)
             {
                 Console.WriteLine("Se ha Eliminado un registro");
             }
         }*/


        /*  public static void GetAll()
          {
              // List<ML.Usuario> usuarios = BL.Usuario.GetAll();
              List<ML.Usuario> usuarios = BL.Usuario.GetAllSP();

              if (usuarios.Count > 0) //trae datos 
              {
                  foreach (ML.Usuario usuario in usuarios)
                  {
                      Console.WriteLine("El Id es: " + usuario.IdUsuario);
                      Console.WriteLine("El UserName es: " + usuario.UserName);
                      Console.WriteLine("El nombre es: " + usuario.Nombre);
                      Console.WriteLine("El Apellido Paterno es: " + usuario.ApellidoPaterno);
                      Console.WriteLine("El Apellido Materno es: " + usuario.ApellidoMaterno);
                      Console.WriteLine("El Email es: " + usuario.Email);
                      Console.WriteLine("El Password es: " + usuario.Password);
                      Console.WriteLine("La Fecaha de Nacimiento es: " + usuario.FechaNacimiento);
                      Console.WriteLine("El Sexo  es: " + usuario.Sexo);
                      Console.WriteLine("El Telefono es: " + usuario.Telefono);
                      Console.WriteLine("El Celular es: " + usuario.Celular);
                      Console.WriteLine("El CURP es: " + usuario.CURP);

                      Console.WriteLine("----------------------------------------------------------------------------------");

                  }

              }
              else
              {
                  Console.WriteLine("La tabla esta vacia");
              }

          }*/


        /*   public static void GetById()
           {
               Console.WriteLine("Ingrese el Id que deseas buacar");
               int Id = int.Parse(Console.ReadLine());
               ML.Usuario usuario = BL.Usuario.GetById(Id);
              // ML.Usuario usuario = BL.Usuario.GetByIdSP(Id);
               if (usuario.IdUsuario != 0) //trae datos 
               {

                   Console.WriteLine("El Id es: " + usuario.IdUsuario);
                   Console.WriteLine("El UserName es: " + usuario.UserName);
                   Console.WriteLine("El nombre es: " + usuario.Nombre);
                   Console.WriteLine("El Apellido Paterno es: " + usuario.ApellidoPaterno);
                   Console.WriteLine("El Apellido Materno es: " + usuario.ApellidoMaterno);
                   Console.WriteLine("El Email es: " + usuario.Email);
                   Console.WriteLine("El Password es: " + usuario.Password);
                   Console.WriteLine("La Fecaha de Nacimiento es: " + usuario.FechaNacimiento);
                   Console.WriteLine("El Sexo  es: " + usuario.Sexo);
                   Console.WriteLine("El Telefono es: " + usuario.Telefono);
                   Console.WriteLine("El Celular es: " + usuario.Celular);
                   Console.WriteLine("El CURP es: " + usuario.CURP);
                   Console.WriteLine("El color de piel es: " + usuario.ApellidoMaterno);
                       Console.WriteLine("----------------------------------------------------------------------------------");



               }
               else
               {
                   Console.WriteLine("La tabla esta vacia");
               }

           }

           */



        public void AddEF()
        {
            ML.Usuario usuario = new ML.Usuario();
            
            Console.WriteLine("Ingresa los siguientes datos");
            Console.WriteLine("Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Apellido paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Apellido materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("UserName: ");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Email: ");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Password: ");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Fecha de nacimiento (YYYY-MM-DD): ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Sexo (M) (F) : ");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Telefono: ");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("CURP: ");
            usuario.CURP = Console.ReadLine();

           Console.WriteLine("Roll: ");
           usuario.Roll = new ML.Roll();

           usuario.Roll.Id_Roll = int.Parse(Console.ReadLine());
            var resultado = BL.Usuario.AddEF(usuario);
            //var resultado = BL.Usuario.AddLINQ(usuario);

            if (resultado.Item1)
            {
                Console.WriteLine("El registro fue exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio algun error " + resultado.Item2);
            }


        }

        public void UpdateEF()
        {

            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el ID que deceas actualizar:");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa los datos a actualizar");

            Console.WriteLine("Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Apellido paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Apellido materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("UserName: ");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Email: ");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Password: ");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Fecha de nacimiento (YYYY-MM-DD): ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Sexo (M) (F) : ");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Telefono: ");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("CURP: ");
            usuario.CURP = Console.ReadLine();

           Console.WriteLine("Roll: ");
           usuario.Roll = new ML.Roll();

           usuario.Roll.Id_Roll = int.Parse(Console.ReadLine());

            var resultado = BL.Usuario.UpdateEF(usuario);
            //var resultado = BL.Usuario.UpdateLINQ(usuario);

            if (resultado.Item1)
            {
                Console.WriteLine("El registro se actualizó con exito");
            }
            else
            {
                Console.WriteLine("Ocurrio algun error " + resultado.Item2);
            }

        }

        public void DeleteEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el ID que deceas eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            //var resultado = BL.Usuario.DeleteEF(usuario);
            var resultado = BL.Usuario.DeleteEF(usuario);

            if (resultado.Item1)
            {

                Console.WriteLine("El usuario se elimino correctamente");

            }
            else
            {
                Console.WriteLine("Ocurrio algun error " + resultado.Item2);
            }
        }

        //public void GetAllEF()
        //{

        //    var resultado = BL.Usuario.GetAllEF();

        //    //var resultado = BL.Usuario.GetAllLINQ();

        //    if (resultado.Item1)
        //    {
        //        foreach (ML.Usuario usuarioRegistro in resultado.Item3.Usuarios)
        //        {
        //            Console.WriteLine("Id usuario:          " + usuarioRegistro.IdUsuario);
        //            Console.WriteLine("Nombre:              " + usuarioRegistro.Nombre);
        //            Console.WriteLine("Apellido paterno:    " + usuarioRegistro.ApellidoPaterno);
        //            Console.WriteLine("Apellido materno:    " + usuarioRegistro.ApellidoMaterno);
        //            Console.WriteLine("UserName:            " + usuarioRegistro.UserName);
        //            Console.WriteLine("Email:               " + usuarioRegistro.Email);
        //            Console.WriteLine("Password:            " + usuarioRegistro.Password);
        //            Console.WriteLine("Fecha de nacimiento: " + usuarioRegistro.FechaNacimiento);
        //            Console.WriteLine("Sexo:                " + usuarioRegistro.Sexo);
        //            Console.WriteLine("Telefono:            " + usuarioRegistro.Telefono);
        //            Console.WriteLine("Celular:             " + usuarioRegistro.Celular);
        //            Console.WriteLine("CURP:                " + usuarioRegistro.CURP);
        //            Console.WriteLine("ID Roll:             " + usuarioRegistro.Roll.Id_Roll);
        //            Console.WriteLine("***************************************");
        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine("Ocurrio un error " + resultado.Item2);
        //    }



        //}

        public void GetByIdEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Inserta el ID de un usuario para ver su registro");

            int IdUsuario = int.Parse(Console.ReadLine());

            var resultado = BL.Usuario.GetByIdEF(IdUsuario);

            if (resultado.Item1)
            {
                ML.Usuario usuarioObj = resultado.Item3;
                Console.WriteLine("Usuario con ID:      " + usuarioObj.IdUsuario);
                Console.WriteLine("Nombre:              " + usuarioObj.Nombre);
                Console.WriteLine("Apellido paterno:    " + usuarioObj.ApellidoPaterno);
                Console.WriteLine("Apellido materno:    " + usuarioObj.ApellidoMaterno);
                Console.WriteLine("UserName:            " + usuarioObj.UserName);
                Console.WriteLine("Email:               " + usuarioObj.Email);
                Console.WriteLine("Password:            " + usuarioObj.Password);
                Console.WriteLine("Fecha de nacimiento: " + usuarioObj.FechaNacimiento);
                Console.WriteLine("Sexo:                " + usuarioObj.Sexo);
                Console.WriteLine("Telefono:            " + usuarioObj.Telefono);
                Console.WriteLine("Celular:             " + usuarioObj.Celular);
                Console.WriteLine("CURP:                " + usuarioObj.CURP);


            }
            else
            {
                Console.WriteLine("Ocurrio un error " + resultado.Item2);
                Exception ex = resultado.Item4;
                //Console.WriteLine(ex);
            }

        }

        public void GetByIdEmail()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Inserta el Email del usuario");
            string email = Console.ReadLine();

            var resultado = BL.Usuario.GetByEmail(email);

            if (resultado.Item1)
            {
                ML.Usuario usuarioObj = resultado.Item3;
                Console.WriteLine("IdUsuario:               " + usuarioObj.IdUsuario);
                Console.WriteLine("Email:               " + usuarioObj.Email);
                Console.WriteLine("Password:            " + usuarioObj.Password);
              


            }
            else
            {
                Console.WriteLine("Ocurrio un error " + resultado.Item2);
                Exception ex = resultado.Item4;
                //Console.WriteLine(ex);
            }

            }


        public void GetAllRoll()
        {
            var resultado = BL.Roll.GetAllRollEF();


            //var resultado = BL.Usuario.GetAllLINQ();

            if (resultado.Item1)
            {
                foreach (ML.Roll rollRegistro in resultado.Item3)

                {
                    Console.WriteLine("Id del Roll:          " + rollRegistro.Id_Roll);
                    Console.WriteLine("Nombre del Roll:      " + rollRegistro.NombreRoll);
                    Console.WriteLine("***************************************");
                }

            }
            else
            {
                Console.WriteLine("Ocurrio un error " + resultado.Item2);
            }


        }
    }

}
    

