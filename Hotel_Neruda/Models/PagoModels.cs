using System;
using Entidad;
namespace Hotel_Neruda.Models
{
    public class PagoInputModel
    {
        public string Codigo {get;set;}
        public string Tipo { get; set; } 
        public DateTime Fecha {get;set;}
        public decimal Valorpago {get;set;}
         public decimal Valoriva {get;set;}
         public string Identificacion { get; set; }
    }
     public class PagoViewModel : PagoInputModel{
        public PagoViewModel()
        {
            
        }
        public PagoViewModel(Pago pago)
        {
            Codigo= pago.Codigo;
            Tipo=pago.Tipo;
            Fecha=pago.Fecha;
            Valorpago=pago.Valorpago;
            Valoriva=pago.Valoriva;
            Identificacion=pago.Identificacion;
        }
    }
}