using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstatusTransporte
    {
        public static (bool, string, List<ML.EstatusTransporte>, Exception) GetAllEstatus()
        {
            List<ML.EstatusTransporte> estatusLista = new List<ML.EstatusTransporte>();

            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var registros = context.GetAllEstatusTransporte().ToList();

                    if (registros.Count > 0)
                    {
                        foreach (var registro in registros)
                        {
                            ML.EstatusTransporte estatusObj = new ML.EstatusTransporte();
                            estatusObj.IdEstatus = registro.IdEstatus;
                            estatusObj.Estatus = registro.Estatus;   

                            estatusLista.Add(estatusObj);
                        }
                        return (true, null, estatusLista, null);
                    }
                    else
                    {
                        return (false, null, estatusLista, null);
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
