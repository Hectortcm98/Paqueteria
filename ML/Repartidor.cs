﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Repartidor
    {

        public int IdRepartidor { get; set; }

        public string Nombre { get; set; }    

        public string ApellidoPaterno { get; set; }

        public  string ApellidoPMaterno { get; set; }

        public List<ML.Repartidor> Repartidores { get; set; }

        public List<object> Repartidores2 { get; set; }

        
    }
}
