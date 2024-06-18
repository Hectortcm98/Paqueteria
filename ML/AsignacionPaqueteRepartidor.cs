using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class AsignacionPaqueteRepartidor
    {

        //public Paquete Paquete { get; set; }
        //public Repartidor Repartidor { get; set; }
        //public DateTime FechaAsignacion { get; set; }

        //public int TotalPaquetes { get; set; }



        public ML.Paquete Paquete { get; set; }

        public ML.Repartidor Repartidor { get; set; }

        public int TotalPaquetes { get; set; }

        public List<ML.AsignacionPaqueteRepartidor> Asignaciones { get; set; }
    }
}
