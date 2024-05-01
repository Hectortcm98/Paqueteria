﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Municipio
    {

        public int Id_Municipio { get; set; }
        public string NombreMunicipio { get; set; }
        public ML.Estado Estado { get; set; }
        public List<ML.Municipio> Municipios { get; set; }
    }
}
