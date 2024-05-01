using Microsoft.Win32;
using ML;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BL
{
    public class Usuario
    {
        /* public static bool Add(ML.Usuario usuario)
         {
             bool resultado = false;
             try
             {
                 //sql conexion a la base de datos 
                 using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))


                 {
                     string query = "INSERT INTO Usuario (UserName,ApellidoPaterno,ApellidoMaterno,Email,Password,FechaNacimiento,Sexo,Telefono,Celular,CURP,Imagen,Nombre)   VALUES (@UserName,@ApellidoPaterno,@ApellidoMaterno,@Email,@Password,@FechaNacimiento,@Sexo,@Telefono,@Celular,@CURP,@Imagen,@Nombre)";




                     //SqlComando - ejecutat sentencias de SQL

                     SqlCommand command = new SqlCommand();
                     command.Connection = context;
                     command.CommandText = query;



                     SqlParameter[] parameters = new SqlParameter[11];

                     parameters[0] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                     parameters[0].Value = usuario.UserName;

                     parameters[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                     parameters[1].Value = usuario.ApellidoPaterno;

                     parameters[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                     parameters[2].Value = usuario.ApellidoMaterno;

                     parameters[3] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                     parameters[3].Value = usuario.Email;

                     parameters[4] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                     parameters[4].Value = usuario.Password;

                     parameters[5] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                     parameters[5].Value = usuario.FechaNacimiento;

                     parameters[6] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                     parameters[6].Value = usuario.Sexo;

                     parameters[7] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                     parameters[7].Value = usuario.Telefono;

                     parameters[8] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                     parameters[8].Value = usuario.Celular;

                     parameters[9] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                     parameters[9].Value = usuario.CURP;

                     parameters[9] = new SqlParameter("@Imagen", System.Data.SqlDbType.VarBinary);
                     parameters[9].Value = usuario.Imagen;

                     parameters[10] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                     parameters[10].Value = usuario.Nombre;

                     command.Parameters.AddRange(parameters);

                     command.Connection.Open();
                     int rowsAffected = command.ExecuteNonQuery();

                     if (rowsAffected > 0)
                     {
                         resultado = true;
                     }
                     else
                     {
                         resultado = false;
                     }
                 }
             }
             catch (Exception ex)
             {
                 resultado = false;
             }

             return resultado;
         }*/
        //store  procedure
        /* public static bool AddSP(ML.Usuario usuario)
         {
             bool resultado = false;
             try
             {
                 //sql conexion a la base de datos 
                 using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                 {
                     string query = "UsuarioAdd";

                     //SqlComando - ejecutat sentencias de SQL

                     SqlCommand command = new SqlCommand(query,context);
                     command.CommandType = CommandType.StoredProcedure;
                    // command.Connection = context;
                    // command.CommandText = query;

                     SqlParameter[] parameters = new SqlParameter[13];

                     parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                     parameters[0].Value = usuario.Nombre;

                     parameters[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                     parameters[1].Value = usuario.ApellidoPaterno;

                     parameters[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                     parameters[2].Value = usuario.ApellidoMaterno;

                     parameters[3] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                     parameters[3].Value = usuario.UserName;

                     parameters[4] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                     parameters[4].Value = usuario.Email;

                     parameters[5] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                     parameters[5].Value = usuario.Password;

                     parameters[6] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.Date);
                     parameters[6].Value = usuario.FechaNacimiento;

                     parameters[7] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                     parameters[7].Value = usuario.Sexo;

                     parameters[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                     parameters[8].Value = usuario.Telefono;

                     parameters[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                     parameters[9].Value = usuario.Celular;

                     parameters[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                     parameters[10].Value = usuario.CURP;

                     parameters[11] = new SqlParameter("@Imagen", System.Data.SqlDbType.VarBinary);
                     parameters[11].Value = usuario.Imagen;

                     parameters[12] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                     parameters[12].Value = usuario.IdUsuario;

                     command.Parameters.AddRange(parameters);

                     command.Connection.Open();
                     int rowsAffected = command.ExecuteNonQuery();
                     command.Connection.Close();
                     if (rowsAffected > 0)
                     {
                         resultado = true;
                     }
                     else
                     {
                         resultado = false;
                     }
                 }
             }
             catch (Exception ex)
             {
                 resultado = false;
             }

             return resultado;
         }
         */

        //
        /*  public static bool AddEF(ML.Usuario usuario )
          {
              bool resultado = false;
              try
              {
                  //sql conexion a la base de datos 
                  using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                  {
                      int rowAffected = context.UsuarioAdd(usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno, usuario.UserName, usuario.Email,usuario.Password,usuario.FechaNacimiento,usuario.Sexo,usuario.Telefono,usuario.Celular,usuario.CURP,null);
                      if (rowAffected > 0)
                      {
                          resultado = true;

                      }
                      else
                      {
                          resultado = false;
                      }
                  }
              }
              catch (Exception ex) 
              {

              }


              return resultado;
          }*/

        public static (bool, string, ML.Usuario, Exception) AddEF(ML.Usuario usuario)
        {
            try
            {
                //sql conexion a la base de datos 
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    int rowsAffected = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName, usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.Roll.Id_Roll, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExteriror, usuario.Direccion.Colonia.Id_Colonia);

                    if (rowsAffected > 0)
                        

                    {
                        //resultado = true;
                        return (true, null, null, null);
                    }
                }
            }


            catch (Exception ex )
            {
                return (false, ex.Message, null, ex);
            }
            return (false, null, null, null);
        }

        public static (bool, string, ML.Usuario, Exception) UpdateEF(ML.Usuario usuario)
        {
               //  bool resultado = false;
            try

            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var rowAffected = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName, usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.Roll.Id_Roll,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExteriror,usuario.Direccion.Colonia.Id_Colonia,usuario.Direccion.Id_Direccion);
                    if (rowAffected > 0)
                    {
                        // resultado = true;
                        return (true, null, null, null);

                    }
                }
            }

            catch (Exception ex)
            {
                return (false, ex.Message, null, ex); //En esta me sale un error, no me permite editar un usuario
            }

            return (false, null, null, null);
        }


        
        public static (bool,string, ML.Usuario, Exception) GetAllEF(ML.Usuario usuarioBusqueda)
        {
            ML.Usuario usuario = new ML.Usuario();

            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())

                {

                    var registros = context.Usuario_GetAll(usuarioBusqueda.Nombre, usuarioBusqueda.ApellidoPaterno, usuarioBusqueda.ApellidoMaterno).ToList();

                    if( registros.Count > 0 )

                    {
                        usuarioBusqueda.Usuarios = new List<object>();

                            foreach (var registro in registros)
                        {
                            
                            ML.Usuario usuarioObj = new ML.Usuario();
                            usuarioObj.IdUsuario = registro.IdUsuario;
                            usuarioObj.Nombre = registro.Nombre;
                            usuarioObj.ApellidoPaterno = registro.ApellidoPaterno;
                            usuarioObj.ApellidoMaterno = registro.ApellidoMaterno;
                            usuarioObj.UserName = registro.UserName;
                            usuarioObj.Password = registro.Password;    
                            usuarioObj.Email = registro.Email;
                            usuarioObj.FechaNacimiento = registro.FechaNacimiento;  
                            usuarioObj.Sexo = registro.Sexo;
                            usuarioObj.Telefono = registro.Telefono;
                            usuarioObj.Celular  = registro.Celular;
                            usuarioObj.CURP = registro.CURP;
                            usuarioObj.Imagen = registro.Imagen;
                            usuarioObj.Estatus = registro.Estatus;

                            




                            //intanciar direccion 
                            usuarioObj.Direccion = new ML.Direccion();
                            usuarioObj.Direccion.Calle = registro.Calle;
                            usuarioObj.Direccion.NumeroInterior = registro.NumeroInterior;
                            usuarioObj.Direccion.NumeroExteriror = registro.NumeroExterior;

                            //Instancia //guarde colonia
                            usuarioObj.Direccion.Colonia = new ML.Colonia();
                            usuarioObj.Direccion.Colonia.Id_Colonia = registro.Id_Colonia.Value;
                            usuarioObj.Direccion.Colonia.NombreColonia = registro.NombreColonia;
                           // usuarioObj.Direccion.Colonia.CodigoPostal = registro.CodigoPostal;

                            //Instancia //guarde Municipio
                            usuarioObj.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuarioObj.Direccion.Colonia.Municipio.Id_Municipio = registro.Id_Municipio.Value;
                            usuarioObj.Direccion.Colonia.Municipio.NombreMunicipio = registro.NombreMunicipio;

                            //Instancia //guarde Estado
                            usuarioObj.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Id_Estado = registro.Id_Estado.Value;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.NombreEstado = registro.NombreEstado;

                            //Instancia //guarde Pais
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais.Id_Pais = registro.Id_Pais.Value;
                            usuarioObj.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = registro.NombrePais;




                            //Instacia 
                            usuarioObj.Roll = new ML.Roll();
                            usuarioObj.Roll.Id_Roll = Convert.ToInt32(registro.Id_Roll);
                            usuarioObj.Roll.NombreRoll = registro.NombreRoll;



                            usuarioBusqueda.Usuarios.Add(usuarioObj);

                        }
                    }
                    return (true, null, usuarioBusqueda, null);
                    
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);

            }
           
        }

        public static (bool, string , ML.Usuario, Exception) GetByIdEF(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var objUsuario = context.UsuarioById(IdUsuario).Single();

                    if (objUsuario != null)
                    {
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();


                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Nombre = objUsuario.Nombre; 
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Email = objUsuario.Email;
                        usuario.Password = objUsuario.Password;
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.CURP = objUsuario.CURP;
                        usuario.Imagen = objUsuario.Imagen;
                        

                        usuario.Roll = new ML.Roll();
                        usuario.Roll.Id_Roll = Convert.ToInt32(objUsuario.Id_Roll);
                        usuario.Roll.NombreRoll = objUsuario.NombreRoll;

                        usuario.Direccion.Id_Direccion = Convert.ToInt32(objUsuario.Id_Direccion);
                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExteriror = objUsuario.NumeroExterior;
                        usuario.Direccion.Colonia.Id_Colonia = Convert.ToInt32(objUsuario.Id_Colonia);
                        //usuario.Direccion.Colonia.CodigoPostal = objUsuario.CodigoPostal;
                        usuario.Direccion.Colonia.NombreColonia = objUsuario.NombreColonia;
                        usuario.Direccion.Colonia.Municipio.Id_Municipio = Convert.ToInt32(objUsuario.Id_Municipio);
                        usuario.Direccion.Colonia.Municipio.NombreMunicipio = objUsuario.NombreMunicipio;
                        usuario.Direccion.Colonia.Municipio.Estado.Id_Estado = Convert.ToInt32(objUsuario.Id_Estado);
                        usuario.Direccion.Colonia.Municipio.Estado.NombreEstado = objUsuario.NombreEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Id_Pais = Convert.ToInt32(objUsuario.Id_Pais);
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = objUsuario.NombrePais;


                        return (true, null, usuario, null);
                    }
                }
                    
                

            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, ex);
            }

            return(false, null,null, null);
        }

        public static (bool, string, ML.Usuario, Exception) DeleteEF(ML.Usuario usuario)
        {
            //bool resultado = false;

            try
            {

                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {

                    int rowsAffected = context.UsuarioDelete(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.UserName, usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono,usuario.Celular, usuario.CURP, null);

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

        public static (bool, string, ML.Usuario, Exception) GetByEmail(string Email)
        {
            ML.Usuario usuario = new ML.Usuario();

            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var objUsuario = context.UsuarioByEmail(Email).Single();

                    if (objUsuario != null)
                    {
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Password = objUsuario.Password;
                        usuario.Email = objUsuario.Email;


                        //Instacia 
                        usuario.Roll = new ML.Roll();
                        usuario.Roll.Id_Roll = objUsuario.Id_Roll.Value;
                        usuario.Roll.NombreRoll = objUsuario.Nombre;
                       

                        

                        
                                             


                        return (true, null, usuario, null);
                    }
                }



            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, ex);
            }

            return (false, null, null, null);
        }

        public static (bool, string, ML.Usuario, Exception) UpdatePassword(ML.Usuario usuario)
        {
            //  bool resultado = false;
            try

            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var rowAffected = context.UpdatePassword( usuario.Email, usuario.Password);

                    new SqlParameter("@Email", usuario.Email);
                    new SqlParameter("@Password", usuario.Password);

                    if (rowAffected > 0)
                    {
                        // resultado = true;
                        return (true, null, null, null);

                    }
                    else
                    {
                        return(false, "No se encontro ningun usuario con este correo proporcionado", null, null);
                    }
                }
            }

            catch (Exception ex)
            {
                return (false, ex.Message, null, ex); //En esta me sale un error, no me permite editar un usuario
            }

            
        }

        public static (bool, string, Exception) CambioEstatus (int IdUsuario, bool Estatus)
        {
            try
            {
                using (DL_EF.ElectronicosEntities context  = new DL_EF.ElectronicosEntities ())
                {
                    var query = context.CambioEstatus(IdUsuario, Estatus);
                    if (query > 0)
                    { 
                    return (true, null, null);
                    }
                    else
                    {
                        return(false, null, null);
                    }
                }
               
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);
                
            }
        }

        //
        /*  public static bool UpdateClient(ML.Usuario usuario)
          {
              bool resultado = false;
              try
              {
                  //sql conexion a la base de datos 
                  using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))

                  //"Data Source=.;Initial Catalog=Electronicos;User ID=sa;Password=***********"
                  {

                      string query = "UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, ColorPiel = @ColorPiel WHERE Id=@Id";


                      //SqlComando - ejecutat sentencias de SQL

                      SqlCommand command = new SqlCommand();
                      command.Connection = context;
                      command.CommandText = query;

                      SqlParameter[] parameters = new SqlParameter[4];

                      parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                      parameters[0].Value = usuario.Nombre;
                      parameters[1] = new SqlParameter("@Apellido", System.Data.SqlDbType.VarChar);
                      parameters[1].Value = usuario.Apellido;
                      parameters[2] = new SqlParameter("@ColorPiel", System.Data.SqlDbType.VarChar);
                      parameters[2].Value = usuario.ColorPiel;
                      parameters[3] = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                      parameters[3].Value = usuario.Id;

                      command.Parameters.AddRange(parameters);

                      command.Connection.Open();
                      int rowsAffected = command.ExecuteNonQuery();
                      if (rowsAffected > 0)
                      {
                          resultado = true;
                      }
                      else
                      {
                          resultado = false;
                      }
                  }
              }
              catch (Exception ex)
              {
                  resultado = false;
              }

              return resultado;
          }*/

        //store  procedure
        /*  public static bool UpdateSP(ML.Usuario usuario)
         {
             bool resultado = false;
             try
             {
                 //sql conexion a la base de datos 
                 using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))

                 //"Data Source=.;Initial Catalog=Electronicos;User ID=sa;Password=***********"
                 {

                     string query = "UsuarioUpdate";


                     //SqlComando - ejecutat sentencias de SQL

                     SqlCommand command = new SqlCommand();

                     command.Connection = context;
                     command.CommandText = query;
                     command.CommandType = CommandType.StoredProcedure;

                     SqlParameter[] parameters = new SqlParameter[13];

                     parameters[0] = new SqlParameter("@IdUsuari", System.Data.SqlDbType.Int);
                     parameters[0].Value = usuario.IdUsuario;

                     parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                     parameters[0].Value = usuario.Nombre;

                     parameters[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                     parameters[1].Value = usuario.ApellidoPaterno;

                     parameters[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                     parameters[2].Value = usuario.ApellidoMaterno;

                     parameters[3] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                     parameters[3].Value = usuario.UserName;

                     parameters[4] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                     parameters[4].Value = usuario.Email;

                     parameters[5] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                     parameters[5].Value = usuario.Password;

                     parameters[6] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.Date);
                     parameters[6].Value = usuario.FechaNacimiento;

                     parameters[7] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                     parameters[7].Value = usuario.Sexo;

                     parameters[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                     parameters[8].Value = usuario.Telefono;

                     parameters[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                     parameters[9].Value = usuario.Celular;

                     parameters[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                     parameters[10].Value = usuario.CURP;

                     parameters[11] = new SqlParameter("@Imagen", System.Data.SqlDbType.VarBinary);
                     parameters[11].Value = usuario.Imagen;

                     parameters[12] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                     parameters[12].Value = usuario.IdUsuario;

                     command.Parameters.AddRange(parameters);

                     command.Connection.Open();
                     int rowsAffected = command.ExecuteNonQuery();
                     command.Connection.Close();
                     if (rowsAffected > 0)
                     {
                         resultado = true;
                     }
                     else
                     {
                         resultado = false;
                     }
                 }
             }
             catch (Exception ex)
             {
                 resultado = false;
             }

             return resultado;
         }*/
        //


        /*   public static bool Delete(ML.Usuario usuario)
           {
               bool resultado = false;
               try
               {
                   //sql conexion a la base de datos 
                   using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))

                   //"Data Source=.;Initial Catalog=Electronicos;User ID=sa;Password=***********"
                   {

                       string query = "DELETE FROM Usuario WHERE Id=@Id";


                       //SqlComando - ejecutat sentencias de SQL

                       SqlCommand command = new SqlCommand();
                       command.Connection = context;
                       command.CommandText = query;

                       SqlParameter[] parameters = new SqlParameter[1];


                       parameters[0] = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                       parameters[0].Value = usuario.Id;

                       command.Parameters.AddRange(parameters);

                       command.Connection.Open();
                       int rowsAffected = command.ExecuteNonQuery();
                       if (rowsAffected > 0)
                       {
                           resultado = true;
                       }
                       else
                       {
                           resultado = false;
                       }
                   }
               }
               catch (Exception ex)
               {
                   resultado = false;
               }

               return resultado;
           }*/
        //store  procedure
        /*  public static bool DeleteSP(ML.Usuario usuario)
          {
              bool resultado = false;
              try
              {
                  //sql conexion a la base de datos 
                  using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))

                  //"Data Source=.;Initial Catalog=Electronicos;User ID=sa;Password=***********"
                  {

                      string query = "UsuarioDelete";


                      //SqlComando - ejecutat sentencias de SQL

                      SqlCommand command = new SqlCommand();
                      command.Connection = context;
                      command.CommandText = query;
                     command.CommandType = CommandType.StoredProcedure;
                      SqlParameter[] parameters = new SqlParameter[1];


                      parameters[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                      parameters[0].Value = usuario.IdUsuario;

                      command.Parameters.AddRange(parameters);

                      command.Connection.Open();
                      int rowsAffected = command.ExecuteNonQuery();
                     command.Connection.Close();
                     if (rowsAffected > 0)
                      {
                          resultado = true;
                      }
                      else
                      {
                          resultado = false;
                      }
                  }
              }
              catch (Exception ex)
              {
                  resultado = false;
              }

              return resultado;
          }*/
        //

        /* public static List<ML.Usuario> GetAll()

          {
              List<ML.Usuario> usuarios = new List<ML.Usuario>();
              try
              {

                  using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                  {
                      string query = "SELECT [ID],[Nombre] ,[Apellido] ,[ColorPiel] FROM [Usuario]";

                      SqlCommand cmd = new SqlCommand();
                      cmd.Connection = context;
                      cmd.CommandText = query;
                      SqlDataAdapter da = new SqlDataAdapter(cmd);  //El datAdapter es para recuperar todo de un jalon los datos
                      DataTable tablaUsuario = new DataTable(); // los data table ya tiene las filas y columnas 

                      da.Fill(tablaUsuario);

                      if (tablaUsuario != null) //Trae datos 
                      {


                          // foreach este nos sive para indicar que losta leer de inicio a fin 
                          foreach (DataRow row in tablaUsuario.Rows) //Tipo de dato que almacena la lista 
                          {
                              ML.Usuario usuario = new ML.Usuario();
                              usuario.Id = int.Parse(row[0].ToString());
                              usuario.Nombre = row[1].ToString();
                              usuario.Apellido = row[2].ToString();
                              usuario.ColorPiel = row[3].ToString();

                              usuarios.Add(usuario); // equivale a datos.push(1)

                          }
                      }
                      else //la tabla esta vacia
                      {

                      }
                  }
              }
              catch (Exception ex)
              {


              }
              return usuarios;

          }*/
        //store  procedure
        /*  public static List<ML.Usuario> GetAllSP()

           {
               List<ML.Usuario> usuarios = new List<ML.Usuario>();
               try
               {

                   using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                   {
                       string query = "UsuarioGetAll";

                       SqlCommand cmd = new SqlCommand();
                       cmd.Connection = context;
                       cmd.CommandText = query;
                     cmd.CommandType = CommandType.StoredProcedure;
                       SqlDataAdapter da = new SqlDataAdapter(cmd);  //El datAdapter es para recuperar todo de un jalon los datos
                       DataTable tablaUsuario = new DataTable(); // los data table ya tiene las filas y columnas 

                       da.Fill(tablaUsuario);

                       if (tablaUsuario != null) //Trae datos 
                       {


                           // foreach este nos sive para indicar que losta leer de inicio a fin 
                           foreach (DataRow row in tablaUsuario.Rows) //Tipo de dato que almacena la lista 
                           {
                               ML.Usuario usuario = new ML.Usuario();
                               usuario.IdUsuario = int.Parse(row[12].ToString());
                               usuario.Nombre = row[0].ToString();
                               usuario.ApellidoPaterno = row[1].ToString();
                               usuario.ApellidoMaterno = row[2].ToString();
                               usuario.UserName = row[3].ToString();   
                               usuario.Email = row[4]. ToString();
                               usuario.Password = row[5].ToString();
                               usuario.FechaNacimiento =row[6].ToString();
                               usuario.Sexo = row[7].ToString();
                               usuario.Telefono = row[8].ToString();
                               usuario.Celular = row[9].ToString();
                               usuario.CURP = row[10].ToString();
                               usuario.Imagen = row[11].ToString();


                               usuarios.Add(usuario); // equivale a datos.push(1)

                           }
                       }
                       else //la tabla esta vacia
                       {

                       }
                   }
               }
               catch (Exception ex)
               {


               }
               return usuarios;

           }*/
        //


        /* public static ML.Usuario GetById(int Id)

          {
              ML.Usuario usuario = new ML.Usuario();
              try
              {

                  using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                  {
                      string query = "SELECT [ID],[Nombre] ,[Apellido] ,[ColorPiel] FROM [Usuario] WHERE Id=@Id";

                      SqlCommand cmd = new SqlCommand();
                      cmd.Connection = context;
                      cmd.CommandText = query; 
                      SqlParameter[] parameters = new SqlParameter[1];
                      parameters[0] = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                      parameters[0].Value = Id;

                      cmd.Parameters.AddRange(parameters);
                      SqlDataAdapter da = new SqlDataAdapter(cmd);  //El datAdapter es para recuperar todo de un jalon los datos
                      DataTable tablaUsuario = new DataTable(); // los data table ya tiene las filas y columnas 

                      da.Fill(tablaUsuario);

                      if (tablaUsuario != null) //Trae datos 
                      {

                          DataRow row = tablaUsuario.Rows[0];

                              usuario.Id = int.Parse(row[0].ToString());
                              usuario.Nombre = row[1].ToString();
                              usuario.Apellido = row[2].ToString();
                              usuario.ColorPiel = row[3].ToString();



                      }
                      else //la tabla esta vacia
                      {

                      }
                  }
              }
              catch (Exception ex)
              {


              }
              return usuario;

          }*/
        //store  procedure

        /* public static ML.Usuario GetByIdSP(int Id)

          {
              ML.Usuario usuario = new ML.Usuario();
              try
              {

                  using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                  {
                      string query = "UsuarioById";

                      SqlCommand cmd = new SqlCommand();
                      cmd.Connection = context;
                      cmd.CommandText = query;
                     cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] parameters = new SqlParameter[1];
                      parameters[0] = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                      parameters[0].Value = Id;

                      cmd.Parameters.AddRange(parameters);
                      SqlDataAdapter da = new SqlDataAdapter(cmd);  //El datAdapter es para recuperar todo de un jalon los datos
                      DataTable tablaUsuario = new DataTable(); // los data table ya tiene las filas y columnas 

                      da.Fill(tablaUsuario);

                      if (tablaUsuario != null) //Trae datos 
                      {

                          DataRow row = tablaUsuario.Rows[0];

                        usuario.IdUsuario = int.Parse(row[12].ToString());
                        usuario.Nombre = row[0].ToString();
                        usuario.ApellidoPaterno = row[1].ToString();
                        usuario.ApellidoMaterno = row[2].ToString();
                        usuario.UserName = row[3].ToString();
                        usuario.Email = row[4].ToString();
                        usuario.Password = row[5].ToString();
                        usuario.FechaNacimiento = row[6].ToString();
                        usuario.Sexo = row[7].ToString();
                        usuario.Telefono = row[8].ToString();
                        usuario.Celular = row[9].ToString();
                        usuario.CURP = row[10].ToString();
                        usuario.Imagen = row[11].ToString();


                    }
                      else //la tabla esta vacia
                      {

                      }
                  }
              }
              catch (Exception ex)
              {


              }
              return usuario;

          }*/
        //


        /*
                public static (bool, string, Exception) AddLINQ(ML.Usuario usuario)
                {
                    try
                    {

                        using ( DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities() )
                        {

                            DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario();

                            usuarioLINQ.Nombre = usuario.Nombre;
                            usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                            usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno; 
                            usuarioLINQ.UserName = usuario.UserName;
                            usuarioLINQ.Email = usuario.Email;
                            usuarioLINQ.Password = usuario.Password;
                            usuarioLINQ.FechaNacimiento = usuario.FechaNacimiento;
                            usuarioLINQ.Sexo = usuario.Sexo;
                            usuarioLINQ.Telefono = usuario.Telefono;
                            usuarioLINQ.Celular = usuario.Celular;
                            usuarioLINQ.CURP    = usuario.CURP;

                            context.Usuarios.Add(usuarioLINQ);

                            int rowsAffected = context.SaveChanges();

                            if (rowsAffected > 0 ) 
                           {
                                return (true,null,null);
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        return (false, ex.Message, ex);
                    }
                    return (false,null,null);
                }

                public static (bool,string, Exception) UpdateLINQ(ML.Usuario usuario)
                {

                    try
                    {

                        using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                       {
                            var query = (from obj in context.Usuarios where obj.IdUsuario.Equals(usuario.IdUsuario) select obj).Single();

                            if (query != null)
                            {
                                query.Nombre = usuario.Nombre;
                                query.ApellidoPaterno = usuario.ApellidoPaterno;
                                query.ApellidoMaterno = usuario.ApellidoMaterno;
                                query.UserName = usuario.UserName;
                                query.Email = usuario.Email;
                                query.Password = usuario.Password;
                                query.FechaNacimiento = usuario.FechaNacimiento;
                                query.Sexo = usuario.Sexo;
                                query.Telefono = usuario.Telefono;
                                query.Celular = usuario.Celular;
                                query.CURP = usuario.CURP;

                                int rowsAffected = context.SaveChanges();

                                if (rowsAffected > 0)
                                {
                                    return (true, null, null);
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        return (false,ex.Message,ex);
                    }
                    return (false,null,null);
                }

                public static (bool, string, Exception) DeleteLINQ( ML.Usuario usuario ) 
                {

                    try
                    {
                        using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                        {

                            var registro = (from obj in context.Usuarios where obj.IdUsuario.Equals(usuario.IdUsuario) select obj).Single();

                            context.Usuarios.Remove(registro);

                            int rowsAffected = context.SaveChanges();

                            if (rowsAffected > 0)
                            {
                                return (true, null, null);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        return(false, ex.Message, ex);

                    }

                    return (false,null,null);
                }

                public static (bool,string,ML.Usuario,Exception) GetAllLINQ()
                {
                    ML.Usuario usuario = new ML.Usuario();
                    try
                    {
                        using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                        {
                            var registros = (from obj in context.Usuarios select obj).ToList();

                            if (registros.Count > 0)
                            {

                                usuario.Usuarios = new List<object>();

                                foreach (var registro in registros)
                                {
                                    ML.Usuario usuarioObj = new ML.Usuario();
                                    usuarioObj.IdUsuario = registro.IdUsuario;
                                    usuarioObj.Nombre = registro.Nombre;
                                    usuarioObj.ApellidoPaterno = registro.ApellidoPaterno;
                                    usuarioObj.ApellidoMaterno = registro.ApellidoMaterno;
                                    usuarioObj.UserName = registro.UserName;
                                    usuarioObj.Email = registro.Email;
                                    usuarioObj.Password = registro.Password;
                                    usuarioObj.FechaNacimiento = registro.FechaNacimiento;
                                    usuarioObj.Sexo = registro.Sexo;
                                    usuarioObj.Telefono = registro.Telefono;
                                    usuarioObj.Celular = registro.Celular;
                                    usuarioObj.CURP = registro.CURP;

                                    usuario.Usuarios.Add(usuarioObj);
                                }
                                return (true, null, usuario, null);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        return (false, ex.Message, null, ex);
                    }
                    return (false, null, null,null);
                }

                public static (bool,string,ML.Usuario,Exception) GetByIdLINQ( int IdUsuario )
                {
                    ML.Usuario usuario = new ML.Usuario();
                    try
                    {
                        using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                        {
                            var query = (from obj in context.Usuarios where obj.IdUsuario.Equals(IdUsuario)  select obj).Single();

                            if (query != null)
                            {

                                usuario.IdUsuario = query.IdUsuario;
                                usuario.Nombre = query.Nombre;
                                usuario.ApellidoPaterno = query.ApellidoPaterno;
                                usuario.ApellidoMaterno = query.ApellidoMaterno;
                                usuario.UserName = query.UserName;
                                usuario.Email = query.Email;
                                usuario.Password = query.Password;
                                usuario.FechaNacimiento = query.FechaNacimiento;
                                usuario.Sexo = query.Sexo;
                                usuario.Telefono = query.Telefono;
                                usuario.Celular = query.Celular;
                                usuario.CURP = query.CURP;

                                return (true, null, usuario, null);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return (false, ex.Message, null, ex);
                    }

                    return (false,null,null,null);
                }

                */
    }
}

    




