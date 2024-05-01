using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SA_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Operaciones" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Operaciones.svc o Operaciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Operaciones : IOperaciones
    {
        public void DoWork()
        {
        }

        public int Suma(int n1, int n2)
        {
            return n1 + n2;
        }

        public int Resta (int n1, int n2)
        {
            return (n1 - n2);
        }

        public int Multiplicacion(int n1, int n2)
        {
            return n1 * n2;
        }
        
       public int Division (int n1, int n2)
        {
            return n1 / n2;
        }
    }
}
