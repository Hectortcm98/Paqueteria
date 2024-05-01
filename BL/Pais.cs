using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        //public static (bool, string, ML.Pais, Exception) GetAll()
        //{
        //    try
        //    {
        //        using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
        //        {
        //            var paises = context.PaisGetAll().ToList();
        //            if (paises.Count > 0)
        //            {
        //                //instancias
        //                ML.Pais pais = new ML.Pais();
        //                pais.Paises = new List<ML.Pais>();

        //                foreach (var Objpais in paises)
        //                {
        //                    ML.Pais pais1 = new ML.Pais();
        //                    pais1.Id_Pais = Objpais.Id_Pais;
        //                    pais1.NombrePais = Objpais.Nombre;

        //                    pais.Paises.Add(pais1);

        //                }

        //                return (true, null, pais, null);

        //            }
        //            else
        //            {
        //                return (false, "NO hay datos en la tabla", null, null);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message, null, ex);
        //    }

        //}

        public static (bool, string, List<ML.Pais>, Exception) GetAll()
        {
            List<ML.Pais> paises = new List<ML.Pais>();

            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())

                {

                    var registros = context.PaisGetAll().ToList();

                    if (registros.Count > 0)

                    {
                        foreach (var registro in registros)
                        {

                            ML.Pais paisObj = new ML.Pais();
                            paisObj.Id_Pais = registro.Id_Pais;
                            paisObj.NombrePais = registro.Nombre;

                            paises.Add(paisObj);


                        }
                        return (true, null, paises, null);
                    }
                    else
                    {
                        return (false, null, paises, null);
                    }


                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);

            }


        }

    }
}
