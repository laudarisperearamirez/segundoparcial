using System;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Pago
    { [Key]
    public string codigo {get;set;}
        public string tipo { get; set; } 
        public  DateTime fecha {get;set;}
        public decimal valorpago {get;set;}
         public decimal valoriva {get;set;}

    }
}