using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Colonia
    {
        public int Id_Colonia { get; set; }

        public string NombreColonia { get; set; }

        public string CodigoPostal { get; set; }

        public List<ML.Colonia> Colonias { get; set; }
        public ML.Municipio Municipio { get; set; }
    }
}
