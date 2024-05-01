using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Transporte
    {


        //public static (bool,string, Exception) AddSP(ML.Transporte transporte)
        // {
        //     bool result = false;
        //     try
        //     {
        //         using (SqlConnection context = new SqlConnection("data source=.;initial catalog=Electronicos;user id=sa;password=pass@word1"))
        //         {
        //             string query = "INSERT INTO Transporte(NumeroPlaca,Modelo,Marca,AñoFricacion,IdEstatus) VALUES " +
        //                 "(@NumeroPlaca,@Modelo,@Marca,@AñoFricacion,@IdEstatus)";
        //             SqlCommand cmd = new SqlCommand();
        //             cmd.Connection = context;
        //             cmd.CommandText = query;

        //             SqlParameter[] parameters = new SqlParameter[5];

        //             parameters[0] = new SqlParameter("@NumeroPlaca", System.Data.SqlDbType.VarChar);
        //             parameters[0].Value = transporte.NumeroPlaca;
        //             parameters[1] = new SqlParameter("@Modelo", System.Data.SqlDbType.VarChar);
        //             parameters[1].Value = transporte.Modelo;
        //             parameters[2] = new SqlParameter("@Marca", System.Data.SqlDbType.VarChar);
        //             parameters[2].Value = transporte.Marca;
        //             parameters[3] = new SqlParameter("@AñoFricacion", System.Data.SqlDbType.DateTime);
        //             parameters[3].Value = transporte.AñoFabricacion;
        //             parameters[4] = new SqlParameter("@IdEstatus", System.Data.SqlDbType.Int);
        //             parameters[4].Value = transporte.Estatus.IdEstatus;

        //             cmd.Parameters.AddRange(parameters);

        //             cmd.Connection.Open();
        //             int rowsAffected = cmd.ExecuteNonQuery();
        //             if (rowsAffected > 0)
        //             {
        //                 result = true;
        //             }
        //             else
        //             {
        //                 result = false;
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {

        //         throw;
        //     }
        // }
        public static (bool, string, ML.Transporte, Exception) Add(ML.Transporte transporte)
        {
            try
            {
                // Cadena de conexión a la base de datos
                string connectionString = "Data Source=.;Initial Catalog=Electronicos;User ID=sa;Password=pass@word1";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Comando para ejecutar el procedimiento almacenado
                    using (SqlCommand command = new SqlCommand("TransporteAdd", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        
                        command.Parameters.AddWithValue("@NumeroPlaca", transporte.NumeroPlaca);
                        command.Parameters.AddWithValue("@Modelo", transporte.Modelo);
                        command.Parameters.AddWithValue("@AñoFabricacion", transporte.AñoFabricacion);
                        command.Parameters.AddWithValue("@IdEstatus", transporte.estatusTransporte.IdEstatus);
                        command.Parameters.AddWithValue("@Marca", transporte.Marca);

                        // Ejecutar el comando y obtener el número de filas afectadas
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return (true, null, null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }

            return (false, null, null, null);
        }
    

        public static (bool, string, ML.Transporte, Exception) GetByIdEF(int IdTransporte)
        {
            ML.Transporte transporte = new ML.Transporte();

            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var objTransporte = context.GetbyidTransporte(IdTransporte).Single();

                    if (objTransporte != null)
                    {
                        transporte.IdTransporte = objTransporte.IdTransporte;
                        transporte.NumeroPlaca = objTransporte.NumeroPlaca;
                        transporte.Modelo = objTransporte.Modelo;                      
                        transporte.AñoFabricacion = objTransporte.AñoFabricacion.Value;
                        transporte.Marca = objTransporte.Marca;


                        transporte.estatusTransporte = new ML.EstatusTransporte();
                        transporte.estatusTransporte.IdEstatus = objTransporte.IdEstatus.Value;
                        transporte.estatusTransporte.Estatus = objTransporte.Estatus;
                       // transporte.estatusTransporte.Estatus = byte.TryParse(objTransporte.Estatus, out byte result) ? result : (byte) 0 ;
                       


                        return (true, null, transporte, null);
                    }
                }



            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, ex);
            }

            return (false, null, null, null);
        }

        public static (bool, string, ML.Transporte, Exception) GetAllLINQ()
        {
            ML.Transporte transporte = new ML.Transporte();
            
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var registros = (from obj in context.Transportes select obj).ToList();

                    if (registros.Count > 0)
                    {

                        transporte.Trasportes = new List<object>();
                        

                        foreach (var registro in registros)
                        {
                            ML.Transporte transporteObj = new ML.Transporte();
                            transporteObj.IdTransporte = registro.IdTransporte;
                            transporteObj.NumeroPlaca = registro.NumeroPlaca;
                            transporteObj.Modelo = registro.Modelo;
                            transporteObj.Marca = registro.Marca;
                            transporteObj.AñoFabricacion = registro.AñoFabricacion.Value;

                            transporteObj.estatusTransporte = new ML.EstatusTransporte();
                            transporteObj.estatusTransporte.IdEstatus = Convert.ToInt32(registro.IdEstatus);
                            transporteObj.estatusTransporte.Estatus = registro.EstatusTransporte.Estatus;
                            //transporteObj.estatusTransporte.Estatus = byte.TryParse(registro.EstatusTransporte.Estatus, out byte result) ? result : (byte)0;
                           


                            transporte.Trasportes.Add(transporteObj);
                           
                        }
                        return (true, null, transporte, null);
                    }

                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
            return (false, null, null, null);
        }

        public static (bool, string, ML.Transporte, Exception) UpdateEF(ML.Transporte transporte)
        {
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var rowAffected = context.UpdateTransporte(
                        transporte.IdTransporte,
                        transporte.NumeroPlaca,
                        transporte.Modelo,
                        transporte.AñoFabricacion,
                        (byte) transporte.estatusTransporte.IdEstatus,
                        transporte.Marca
                    );

                    if (rowAffected > 0)
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

        public static (bool, string, ML.Transporte, Exception) DeleteEF(ML.Transporte transporte)
        {
            //bool resultado = false;

            try
            {

                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {

                    int rowsAffected = context.TransporteDelete(transporte.IdTransporte,transporte.NumeroPlaca, transporte.Modelo,transporte.AñoFabricacion, transporte.Marca);

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
