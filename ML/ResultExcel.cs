using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ResultExcel
    {
        public int IdRegistro { get; set; }
        public string Mensaje { get; set; }
        public List<Paquete> Paquetes { get; set; } // Nueva propiedad para almacenar los paquetes

        // Constructor
        public ResultExcel()
        {
            Paquetes = new List<Paquete>(); // Inicializa la lista de paquetes en el constructor
        }

        public List<ResultExcel> Errores { get; set; }
    }
}
