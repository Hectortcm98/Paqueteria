﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Repartidor
    {
        public static (bool, string, ML.Repartidor, Exception) GetById(int IdRepartidor)
        {
            //List<ML.Repartidor> repartidores = new List<ML.Repartidor>();
            ML.Repartidor repartidores = new ML.Repartidor();

            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    //var repartidor = context.GetByIdRepartidor(IdRepartidor).ToList();
                    var query = (from obj in context.Repartidors where obj.IdRepartidor.Equals(IdRepartidor) select obj).Single();
                    //var estados = context.EstadoGetByIdPais(Id_Pais).ToList();

                    //if (repartidor.Count > 0)
                        if (query != null)
                        {



                        //foreach (var ObjRepartidor in repartidor)

                        //ML.Repartidor repartir = new ML.Repartidor();

                        repartidores.IdRepartidor = query.IdRepartidor;
                        repartidores.Nombre = query.Nombre;
                        repartidores.ApellidoPaterno  = query.ApellidoPaterno;
                        repartidores.ApellidoPMaterno = query.ApellidoPMaterno;

                            
                            
                            

                            //repartidores.Add(repartir);
                            //estado.Add(estado1);

                        


                        return (true, null, repartidores, null);
                    }

                }

            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, ex);
            }

            return (false, null, null, null);
        }


        //public static (bool, string, List<ML.Repartidor>, Exception) GetAllEF()
        //{
        //    List<ML.Repartidor> repartidores = new List<ML.Repartidor>();

        //    try
        //    {
        //        using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
        //        {
        //            var registros = context.GetAllRepartidor().ToList();

        //            if (registros.Count > 0)
        //            {
        //                foreach (var registro in registros)
        //                {
        //                    ML.Repartidor repartidorObj = new ML.Repartidor();
        //                    repartidorObj.IdRepartidor = registro.IdRepartidor;
        //                    repartidorObj.Nombre = registro.Nombre;
        //                    repartidorObj.ApellidoPaterno = registro.ApellidoPaterno;
        //                    repartidorObj.ApellidoPMaterno = registro.ApellidoPMaterno;

        //                    repartidores.Add(repartidorObj);
        //                }
        //            }
        //            return (true, null, repartidores, null);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message, null, ex);
        //    }
        //}

        public static (bool, string, ML.Repartidor, Exception) GetAllEF()
        {
            ML.Repartidor repartidores = new ML.Repartidor();

            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var registros = context.GetAllRepartidor().ToList();

                    if (registros.Count > 0)
                    {
                        repartidores.Repartidores = new List<ML.Repartidor>();
                        foreach (var registro in registros)
                        {
                            ML.Repartidor repartidorObj = new ML.Repartidor();
                            repartidorObj.IdRepartidor = registro.IdRepartidor;
                            repartidorObj.Nombre = registro.Nombre;
                            repartidorObj.ApellidoPaterno = registro.ApellidoPaterno;
                            repartidorObj.ApellidoPMaterno = registro.ApellidoPMaterno;

                            repartidores.Repartidores.Add(repartidorObj);
                        }
                    }
                    return (true, null, repartidores, null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }

        public static (bool, string, ML.Repartidor, Exception) UpdateEF(ML.Repartidor repartidor)
        {
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var rowAffeccted = context.UpdateRepartidor(repartidor.IdRepartidor, repartidor.Nombre,repartidor.ApellidoPaterno,repartidor.ApellidoPMaterno);
                    if (rowAffeccted > 0)
                    {
                        return (true, null, null, null);
                    }
                }

            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, ex);
            }
            return (false, null, null, null);
        }

        public static (bool, string, ML.Repartidor, Exception) AddEF(ML.Repartidor repartidor)
        {
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    int rowsAffected = context.AddRepartidor(repartidor.Nombre, repartidor.ApellidoPaterno, repartidor.ApellidoPMaterno);

                    if (rowsAffected > 0)
                    {
                        return (true, null, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);

            }
            return (false, null, null, null);
        }

        public static (bool, string, ML.Repartidor, Exception) DeleteEF(ML.Repartidor repartidor)
        {
            //bool resultado = false;

            try
            {

                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {

                    int rowsAffected = context.DeleteRepartidor( repartidor.IdRepartidor,repartidor.Nombre, repartidor.ApellidoPaterno,repartidor.ApellidoPMaterno);

                    if (rowsAffected > 0)
                    {

                        return (true, null, null, null);

                    }

                }

            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }

            return (false, null, null, null);
        }

        
    }
}
