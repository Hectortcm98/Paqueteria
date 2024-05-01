using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int Id_Direccion { get; set; }

        public string Calle { get; set; }

        public string NumeroInterior { get; set; }

        public string NumeroExteriror { get; set; }

        public ML.Colonia Colonia { get; set; }
    }
}
