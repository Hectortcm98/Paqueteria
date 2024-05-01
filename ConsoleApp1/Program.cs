using BL;
using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)

        {
            var result = BL.Paquete.CargaMasivaTxT();
            
            if (result.Item1)
            {
                Console.WriteLine("Fue exitosa");

                Console.WriteLine(result.Item2);
            }
            else 
            {
                Console.WriteLine("Fallo");
                Console.WriteLine(result.Item3.Message);
            }

            Console.ReadKey();



            //byte opcion;

            //Usuario usuarios = new Usuario();
            //while (true)
            //{
            //    Console.WriteLine("¿Que deceas realizar?");
            //    Console.WriteLine("1.- Agregar un usuario");
            //    Console.WriteLine("2.- Editar un usuario");
            //    Console.WriteLine("3.- Eliminar un usuario");
            //    Console.WriteLine("4.- Visualizar todos los registros");
            //    Console.WriteLine("5.- Consultar información de un usuario");
            //    Console.WriteLine("6.- Consultar email de un usuario");
            //    Console.WriteLine("7.- Consultar los rolles de los usuarios");
            //    Console.WriteLine("8.- Salir");

            //    opcion = byte.Parse(Console.ReadLine());



            //    switch (opcion)
            //    {
            //        case 1:
            //            //usuarios.Add();

            //            usuarios.AddEF();
            //            break;

            //        case 2:
            //            //usuarios.Update();

            //            usuarios.UpdateEF();
            //            break;

            //        case 3:
            //            //usuarios.Delete();

            //            usuarios.DeleteEF();
            //            break;

            //        case 4:
            //            //usuarios.GetAll();

            //        //    usuarios.GetAllEF();
            //        //    break;
            //        //case 5:
            //            //usuarios.GetById();

            //            usuarios.GetByIdEF();
            //            break;

            //        case 6:
            //            //usuarios.GetById();

            //            usuarios.GetByIdEmail();
            //            break;

            //        case 7:
            //            //usuarios.GetById();

            //            usuarios.GetAllRoll();
            //            break;


            //        case 8:
            //            Console.WriteLine("Saliendo del programa....");
            //            return;

            //        default:
            //            Console.WriteLine("Opcion no valida");
            //            break;

            //    }
            //}
        }
    }
    }




