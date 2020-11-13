using System;
using Entidad;
namespace Hotel_Neruda.Models
{
    public class PagoInputModel
    {
        public string Codigo {get;set;}
        public string Tipo { get; set; } 
        public DateTime Fecha {get;set;}
        public decimal ValorPago {get;set;}
         public decimal ValorIva {get;set;}
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
            ValorIva=pago.ValorIva;
            ValorPago=pago.ValorPago;
            Identificacion=pago.Identificacion;
        }
    }
}