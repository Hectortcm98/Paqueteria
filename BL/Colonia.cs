using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {

        public static (bool, string, List<ML.Colonia>, Exception) GetByIdMunicipio(int Id_Municipio)
        {
            List<ML.Colonia> colonia = new List<ML.Colonia>();
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var colonias = context.ColoniaGetByIdMunicipio(Id_Municipio).ToList();

                    if (colonias.Count > 0)
                    {

                     

                        foreach (var ObjColonia in colonias)
                        {
                            ML.Colonia colonia1 = new ML.Colonia();
                            colonia1.Id_Colonia= ObjColonia.Id_Colonia;
                            colonia1.NombreColonia = ObjColonia.Nombre;

                            colonia.Add(colonia1);

                        }


                        return (true, null, colonia, null);
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
