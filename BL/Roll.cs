using System.Collections.Generic;
using System.Linq;
using System;

namespace BL
{
    public class Roll
    {
        public static (bool, string, List<ML.Roll>, Exception) GetAllRollEF()
        {
            List<ML.Roll> rolLista = new List<ML.Roll>();

            try
            {
                using (DL_EF.ElectronicosEntities context = new DL_EF.ElectronicosEntities())
                {
                    var registros = context.RollGetAll().ToList();

                    foreach (var registro in registros)
                    {
                        ML.Roll rollObj = new ML.Roll();
                        rollObj.Id_Roll = registro.Id_Roll;
                        rollObj.NombreRoll = registro.Nombre;

                        rolLista.Add(rollObj);
                    }

                    if (rolLista.Count > 0)
                    {
                        return (true, null, rolLista, null);
                    }
                    else
                    {
                        return (false, null, rolLista, null);
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
