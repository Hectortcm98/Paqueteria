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
    
    public partial class Direccion
    {
        public int Id_Direccion { get; set; }
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        public string NumeroExterior { get; set; }
        public Nullable<int> Id_Colonia { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    
        public virtual Colonia Colonia { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
