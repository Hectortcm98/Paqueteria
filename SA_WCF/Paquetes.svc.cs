using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SA_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Paquetes" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Paquetes.svc o Paquetes.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Paquetes : IPaquetes
    {
        

        public  (bool, string, List<ML.Paquete>, Exception) GetAll()
        {
            var result = BL.Paquete.GetAllClient();

            return(result.Item1,result.Item2,result.Item3,result.Item4);
        }
        public  (bool, string, ML.Paquete, Exception) Add(ML.Paquete paquete)
        {
            var result = BL.Paquete.AddEF(paquete);

            return(result.Item1,result.Item2,result.Item3,result.Item4);
        }

        public (bool, string, ML.Paquete, Exception) UpdateEF(ML.Paquete paquete)
        {
            var result = BL.Paquete.UpdateEF(paquete);

            return (result.Item1, result.Item2, result.Item3, result.Item4);
        }

        public (bool, string, ML.Paquete, Exception) GetById(int IdPaquete)
        {
            var result = BL.Paquete.GetByIdLINQ(IdPaquete);

            return (result.Item1, result.Item2, result.Item3, result.Item4);
        }


        public (bool, string, Exception) DeleteLINQ(int IdPaquete)
        {
            var result = BL.Paquete.DeleteLINQ(IdPaquete);

            return (result.Item1, result.Item2, result.Item3);
        }

    }
}
