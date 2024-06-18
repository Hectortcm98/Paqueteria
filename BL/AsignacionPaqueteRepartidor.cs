using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AsignacionPaqueteRepartidor
    {

        public static (bool, string, ML.AsignacionPaqueteRepartidor, Exception) AddEF(int IdPaquete, int IdRepartidor)
        {
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    int rowsAffected = context.AsignarPaqueteRepartidor(IdPaquete, IdRepartidor);

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



        public static (bool, string, ML.AsignacionPaqueteRepartidor, Exception) ModificarCatidad(int IdRepartidor, int Cantidad)
        {
            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    int rowsAffected = context.ModificarTotalPaquetes( IdRepartidor, Cantidad);

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
