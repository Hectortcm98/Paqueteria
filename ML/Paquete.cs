using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ML
{
    public class Paquete
    {


        public int IdPaquete { get; set; }




        [Display(Name = "Instruccion de Entrega")]
        [Required(ErrorMessage = "campo requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres")]
        public string InstruccionEntrega { get; set; }

        public decimal Peso { get; set; }


        [Display(Name = "Dirección de Origen")]
        public string DireccionOrigen { get; set; }



        [Display(Name = "Dirección de Entrega")]
        public string DireccionEntrega { get; set; }


     
        [Display(Name = "Fecha Estimada de Entrega")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime FechaEstimadaEntrega { get; set; }

        [Display(Name = "Número Guía")]
        public string NumeroGuia { get; set; }


        [Display(Name = "Código de paquete")]
        public string CodigoQR { get; set; }

        

        public List<ML.Paquete> paqueteLista { get; set; }

        public ML.Repartidor Repartidor { get; set; }
    }
}
