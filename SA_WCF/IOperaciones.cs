using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SA_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IOperaciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        void DoWork();

        //suma
        [OperationContract]
        int Suma (int n1, int n2);

        //resta
        [OperationContract]
        int Resta(int n1, int n2);

        [OperationContract]
        int Multiplicacion(int n1, int n2);

        [OperationContract]
        int Division(int n1, int n2);
    }
}
