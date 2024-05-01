using DL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public  class Municipio
    {

        public static (bool, string, List<ML.Municipio>, Exception) GetByIdEstado(int Id_Estado)
        {
            List<ML.Municipio> municipio = new List<ML.Municipio>();
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var municipios = context.MunicipioGetByIdEstado(Id_Estado).ToList();

                    if (municipios.Count > 0)
                    {

                       

                        foreach (var ObjMunicipio in municipios)
                        {
                            ML.Municipio municipio1 = new ML.Municipio();
                            municipio1.Id_Municipio = ObjMunicipio.Id_Municipio;
                            municipio1.NombreMunicipio = ObjMunicipio.Nombre;

                            municipio.Add(municipio1);

                        }


                        return (true, null, municipio, null);
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
