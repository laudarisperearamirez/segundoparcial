using System;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Pago
    { [Key]
    public string Codigo {get;set;}
        public string Tipo { get; set; } 
        public  DateTime Fecha {get;set;}
        public decimal Valorpago {get;set;}
         public decimal Valoriva {get;set;}
         public string Identificacion { get; set; }
         

    }
}