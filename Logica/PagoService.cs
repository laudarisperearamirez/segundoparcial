using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class PagoService
    {
        private readonly NerudaContext _context;
        public PagoService(NerudaContext context)
        {
            _context = context;
        }
        public GuardarPagoResponse Guardar(Pago pago){
            try
            {
                var pagoBuscar = _context.Pago.Find(pago.Codigo);
                if(pagoBuscar != null){
                    return new GuardarPagoResponse($"Error el pago {pago.Codigo} ya se encuentra registrado");
                }
                _context.Pago.Add(pago);
                _context.SaveChanges();
                return new GuardarPagoResponse(pago);
            }
            catch (Exception e)
            {
                
                return new GuardarPagoResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public List<Pago> ConsultarTodos(){
            List<Pago> pagos=_context.Pago.ToList();
            return pagos;
        }
        
        public Pago BuscarxIdentificacion(string id){
            Pago pago= _context.Pago.Find(id);
            return pago;
        }
    }
    public class GuardarPagoResponse
    {
        public GuardarPagoResponse(Pago pago)
        {
            Error = false;
            Pago = pago;
        }

        public GuardarPagoResponse(string mensaje)

        {

            Error = true;

            Mensaje = mensaje;

        }

        public bool Error { get; set; }

        public string Mensaje { get; set; }

        public Pago Pago { get; set; }

    }
}
