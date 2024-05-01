using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {

        public static (bool, string, List<ML.Estado>, Exception) GetByIdPais(int Id_Pais)
        {
            List<ML.Estado> estado = new List<ML.Estado>();

            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var estados = context.EstadoGetByIdPais(Id_Pais).ToList();

                    if (estados.Count > 0)
                    {

                        

                        foreach (var ObjEstado in estados)
                        {
                            ML.Estado estado1 = new ML.Estado();
                            estado1.Id_Estado = ObjEstado.Id_Estado;
                            estado1.NombreEstado = ObjEstado.Nombre;

                            estado.Add(estado1);

                        }


                        return (true, null, estado, null);
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
