using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SA_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPaquetes" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPaquetes
    {


        [OperationContract]
        (bool, string, List<ML.Paquete>, Exception) GetAll();


        [OperationContract]
        (bool, string, ML.Paquete, Exception) Add(ML.Paquete paquete);


        [OperationContract]
        (bool, string, ML.Paquete, Exception) UpdateEF(ML.Paquete paquete);

        [OperationContract]
        (bool, string, ML.Paquete, Exception) GetById(int IdPaquete);

        [OperationContract]
        (bool, string, Exception) DeleteLINQ(int IdPaquete);
    }



}
