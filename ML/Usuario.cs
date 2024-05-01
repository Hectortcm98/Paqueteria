using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Usuario
    {
        public int  IdUsuario { get;  set; }







        [Required(ErrorMessage = "campo requeridoo")]
        public string UserName { get; set; }






        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "campo requeridoo")]
        public string Nombre { get; set; }






        [Required(ErrorMessage = "campo requeridoo")]
        [Display(Name = "Apellido Paterno")]
        [StringLength(50)]
        public string ApellidoPaterno { get; set; }






        [MaxLength(10), MinLength(5)]
        [Display(Name = "Apellido Materno")]
        //[RegularExpression("/[^a-zA-Z\\s]/")]
        public string ApellidoMaterno { get; set; }





        [Required(ErrorMessage = "campo requeridoo")]
        public string Email { get; set; }






        [Required(ErrorMessage = "campo requeridoo")]
        public string Password { get; set; }







        [Required(ErrorMessage = "campo requeridoo")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }







        [Required(ErrorMessage = "campo requeridoo")]
        public string Sexo { get; set; }






        [Required(ErrorMessage = "campo requeridoo")]
        public string Telefono { get; set; }






        [Required(ErrorMessage = "campo requeridoo")]
        public string Celular { get; set; }






        [Required(ErrorMessage = "campo requeridoo")]
        public string CURP { get; set; }







        public  List<object> Usuarios { get; set; }








        public string Imagen { get; set; }









        public bool Estatus { get; set; }








       

        public ML.Roll  Roll { get; set; }  









        public ML.Direccion Direccion { get; set; }





       


        /*  Nombre  ,
ApellidoPaterno 
ApellidoMaterno ,
UserName 
Email 
Password 
FechaNacimiento 
Sexo 
Telefono
Celular 
CURP 
Imagen*/
    }
}
