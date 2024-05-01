using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class EstatusTransporte
    {

        public int  IdEstatus {get; set; }
        public  string Estatus { get; set; }

        public List<ML.EstatusTransporte> EstatusLista = new List<ML.EstatusTransporte>();

    }
}
