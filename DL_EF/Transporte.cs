//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transporte
    {
        public int IdTransporte { get; set; }
        public string NumeroPlaca { get; set; }
        public string Modelo { get; set; }
        public Nullable<System.DateTime> AñoFabricacion { get; set; }
        public Nullable<byte> IdEstatus { get; set; }
        public string Marca { get; set; }
    
        public virtual EstatusTransporte EstatusTransporte { get; set; }
    }
}
