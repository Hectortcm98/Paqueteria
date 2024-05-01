using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace BL
{
    public class Paquete
    {

        public static (bool, string, ML.Paquete, Exception) AddEF(ML.Paquete paquete)
        {
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    int rowsAffected = context.AddPaquete(paquete.InstruccionEntrega, paquete.Peso, paquete.DireccionOrigen, paquete.DireccionEntrega, paquete.FechaEstimadaEntrega, paquete.NumeroGuia, null);

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


        public static (bool, string, ML.Paquete, Exception) UpdateEF(ML.Paquete paquete)
        {
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var rowAffeccted = context.UpdatePaquete(paquete.IdPaquete, paquete.InstruccionEntrega, paquete.Peso, paquete.DireccionOrigen, paquete.DireccionEntrega, paquete.FechaEstimadaEntrega, paquete.NumeroGuia, paquete.CodigoQR);
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

        public static (bool, string, List<ML.Paquete>, Exception) GetAllClient()
        {
            //List<ML.Paquete> paquetesLis = new List<ML.Paquete>();
            List<ML.Paquete> paquete = new List<ML.Paquete>();
            {
                try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                    {
                        string query = "SELECT  Paquete.IdPaquete,   Paquete.InstruccionEntrega,   Paquete.Peso,   Paquete.DireccionOrigen,   Paquete.DireccionEntrega,   Paquete.FechaEstimadaEntrega,   Paquete.NumeroGuia,  Paquete.CodigoQR FROM Paquete";

                        SqlCommand command = new SqlCommand();
                        command.Connection = context;
                        command.CommandText = query;

                        SqlDataAdapter adapter = new SqlDataAdapter(command); // recupera la tabla

                        DataTable tablaPaquetes = new DataTable();

                        adapter.Fill(tablaPaquetes);

                        if (tablaPaquetes != null) //Diferente a vacio
                        {


                            foreach (DataRow row in tablaPaquetes.Rows)
                            {
                                ML.Paquete paquete1 = new ML.Paquete(); //  Se crea el objeto
                                paquete1.IdPaquete = int.Parse(row[0].ToString()); //  El arreglo recuperara cada fila por cada campo que tengamos
                                paquete1.InstruccionEntrega = row[1].ToString();
                                paquete1.Peso = decimal.Parse(row[2].ToString());
                                paquete1.DireccionOrigen = row[3].ToString();
                                paquete1.DireccionEntrega = row[4].ToString();
                                paquete1.FechaEstimadaEntrega = DateTime.Parse(row[5].ToString());
                                paquete1.NumeroGuia = row[6].ToString();
                                paquete1.CodigoQR = row[7].ToString();

                                paquete.Add(paquete1); //del objeto del list "usuario" le pasara al metodo los objetos del ML.usurio
                            }
                            return (true, null, paquete, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return (false, ex.Message, null, null);
                }
                return (true, null, null, null);
            }

        }


        public static (bool, string, ML.Paquete, Exception) GetByIdLINQ(int IdPaquete)
        {
            ML.Paquete paquete = new ML.Paquete();
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var query = (from obj in context.Paquetes where obj.IdPaquete.Equals(IdPaquete) select obj).Single();


                    if (query != null)
                    {

                        paquete.IdPaquete = query.IdPaquete;
                        paquete.InstruccionEntrega = query.InstruccionEntrega;
                        paquete.Peso = query.Peso;
                        paquete.DireccionOrigen = query.DireccionOrigen;
                        paquete.DireccionEntrega = query.DireccionEntrega;
                        paquete.FechaEstimadaEntrega = query.FechaEstimadaEntrega;
                        paquete.NumeroGuia = query.NumeroGuia;
                        paquete.CodigoQR = query.CodigoQR;

                        //paquete.Repartidor = new ML.Repartidor();
                        //paquete.Repartidor.IdRepartidor = int.Parse(query.IdRepartidor);
                        //paquete.Repartidor.Nombre = query.Repartidor.Nombre;
                        //paquete.Repartidor.ApellidoPaterno = query.Repartidor.ApellidoPaterno;
                        //paquete.Repartidor.ApellidoPMaterno = query.Repartidor.ApellidoPMaterno;


                        return (true, null, paquete, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }

            return (false, null, null, null);
        }

        public static (bool, string, ML.Paquete, Exception) GetByCodigoLINQ(string Codigo)
        {
            ML.Paquete paquete = new ML.Paquete();
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var query = (from obj in context.Paquetes where obj.CodigoQR.Equals(Codigo) select obj).Single();


                    if (query != null)
                    {

                        paquete.IdPaquete = query.IdPaquete;
                        paquete.InstruccionEntrega = query.InstruccionEntrega;
                        paquete.Peso = query.Peso;
                        paquete.DireccionOrigen = query.DireccionOrigen;
                        paquete.DireccionEntrega = query.DireccionEntrega;
                        paquete.FechaEstimadaEntrega = query.FechaEstimadaEntrega;
                        paquete.NumeroGuia = query.NumeroGuia;
                        paquete.CodigoQR = query.CodigoQR;

                        

                        return (true, null, paquete, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }

            return (false, null, null, null);
        }


        public static (bool success, string errorMessage, Exception exception) DeleteLINQ(int IdPaquete)
        {
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    // Buscar el registro por IdPaquete
                    var registro = context.Paquetes.FirstOrDefault(obj => obj.IdPaquete == IdPaquete);

                    // Verificar si el registro existe
                    if (registro != null)
                    {
                        // Eliminar el registro
                        context.Paquetes.Remove(registro);
                        int rowsAffected = context.SaveChanges();

                        // Verificar si se eliminó el registro exitosamente
                        if (rowsAffected > 0)
                        {
                            return (true, null, null); // Éxito
                        }
                        else
                        {
                            return (false, "No se eliminó ningún registro.", null);
                        }
                    }
                    else
                    {
                        return (false, "No se encontró el registro con el IdPaquete especificado.", null);
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                // Manejar excepción específica de Entity Framework relacionada con la base de datos
                return (false, "Error al actualizar la base de datos: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones
                return (false, "Error inesperado: " + ex.Message, ex);
            }
        }


        public static (bool, string, Exception) CargaMasivaTxT()
        {

            string path = @"C:\Users\digis\Documents\Hector Antonio Canales Mejia\HCanalesProgramacionCapas\CargaMasiva.txt";
            try



            {
                if (File.Exists(path))
                {
                    StreamReader reader = new StreamReader(path);
                    string linea;

                    int contador = 0;

                    while ((linea = reader.ReadLine()) != null) //linea esta valiendo "", por lo tanto es diferente de null y entra
                    {
                        if (contador > 0)
                        {
                            string[] datos = linea.Split('|');
                            ML.Paquete paquete = new ML.Paquete();
                            paquete.InstruccionEntrega = datos[0];
                            paquete.Peso = decimal.Parse(datos[1]);
                            paquete.DireccionOrigen = datos[2];
                            paquete.DireccionEntrega = datos[3];

                            paquete.FechaEstimadaEntrega = DateTime.Parse(datos[4]);

                            paquete.NumeroGuia = datos[5];
                            //paquete.CodigoQR = Encoding.UTF8.GetBytes(datos[6]);

                            BL.Paquete.AddEF(paquete);
                        }

                        contador++;

                    }
                    return (true, null, null);

                }
                else
                {
                    return (false, null, null);
                }
            }
            catch (Exception ex)
            {

                return (false, null, ex);

            }

        }


        public static (bool, string, List<ML.Paquete>, Exception) CargaMasivaExcel(string connectionString)
        {
            try
            {
                using (OleDbConnection context = new OleDbConnection(connectionString))
                {
                    var query = "SELECT * FROM [Hoja1$]";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.Connection.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    DataTable tablePaquete = new DataTable();
                    da.Fill(tablePaquete);

                    if (tablePaquete.Rows.Count > 0)
                    {
                        List<ML.Paquete> paquetes = new List<ML.Paquete>();

                        foreach (DataRow row in tablePaquete.Rows)
                        {
                            ML.Paquete paquete = new ML.Paquete();

                            paquete.InstruccionEntrega = row[0].ToString();
                            paquete.Peso = decimal.Parse(row[1].ToString());
                            paquete.DireccionOrigen = row[2].ToString();
                            paquete.DireccionEntrega = row[3].ToString();
                            paquete.FechaEstimadaEntrega = DateTime.Parse(row[4].ToString());
                            paquete.NumeroGuia = row[5].ToString();

                            paquetes.Add(paquete);

                        }
                        return (true, "", paquetes, null);
                    }
                    else
                    {
                        return (false, "", null, null);
                    }
                }

            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);

            }
        }


        public static (ML.ResultExcel, Exception) ValidarDatos(List<ML.Paquete> paquetes)
        {
            try
            {
                ML.ResultExcel resultExcel = new ML.ResultExcel();//Solo para regresar la lista de los errores


                string Mensaje = "";
                int contador = 2;
                resultExcel.Errores = new List<ML.ResultExcel>();


                foreach (ML.Paquete paquete in paquetes)
                {

                    Mensaje = "";
                    Mensaje += (paquete.InstruccionEntrega == null) ? "No tiene instrucciones, " : "";
                    Mensaje += (paquete.Peso == 0) ? "No tiene el campo peso, " : "";
                    Mensaje += (paquete.DireccionOrigen == null) ? "No tiene direccion de origen, " : "";
                    Mensaje += (paquete.DireccionEntrega == null) ? "No tiene direccion de entrega, " : "";
                    Mensaje += (paquete.FechaEstimadaEntrega == null) ? "No tiene fecha de entrega, " : "";
                    Mensaje += (paquete.NumeroGuia == null) ? "No tiene nuemro de guia, " : "";


                    if (Mensaje == null)//SI hay errores
                    {
                        ML.ResultExcel errorFila = new ML.ResultExcel();
                        errorFila.IdRegistro = 2; // lee desde la fila donde inicia el conte d elo registros del documento
                        errorFila.Mensaje = Mensaje;

                        resultExcel.Errores.Add(errorFila);
                    }
                    contador++;
                }

                return (resultExcel, null);
            }

            catch (Exception ex)
            {
                return (null, ex);

            }
        }




    }
}
