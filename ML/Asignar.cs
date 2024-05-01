using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Asignar
    {
        //public List<object> Paquetes { get; set; }
        //public int TotalPaquetes { get; set; }
        //public decimal Catidad { get; set; }
        //public decimal Total { get; set; }


      
        public ML.Paquete Paquete { get; set; }

        public ML.Repartidor Repartidor { get; set; }

        public int TotalPaquetes { get; set; }

        public List<ML.Asignar> Asignacion { get; set; }


    }
}
