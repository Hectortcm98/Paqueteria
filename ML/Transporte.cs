using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Transporte
        //Propiedades de la tabla Transporte
    {
        public int IdTransporte { get ; set; }
        public string NumeroPlaca { get; set;}
        public string Modelo { get; set; }
        
        public DateTime AñoFabricacion { get; set; }
        public ML.EstatusTransporte estatusTransporte { get; set; }

        public string Marca { get; set; }
        public List<object> Trasportes { get; set; }

        public List<ML.Paquete> Listapaquete = new List<ML.Paquete>();

    }
}
