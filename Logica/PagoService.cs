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
                var pagoBuscar = _context.Pagos.Find(pago.codigo);
                if(pagoBuscar != null){
                    return new GuardarPagoResponse($"Error el pago {pago.codigo} ya se encuentra registrado");
                }
                _context.Pagos.Add(pago);
                _context.SaveChanges();
                return new GuardarClienteResponse(pago);
            }
            catch (Exception e)
            {
                
                return new GuardarPagoResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public List<Pago> ConsultarTodos(){
            List<Pago> pagos=_context.Pagos.ToList();
            return pagos;
        }
        public string Eliminar(string id){
            try
            {
                var pago= _context.Pagos.Find(id);
                if(pago != null){
                    _context.Clientes.Remove(pago);
                    _context.SaveChanges();
                    return ($"El pago {pago.codigo} se ha eliminado exitosamente");
                }else{
                    return ($"Error, el pago con identificacion {pago.codigo} no existe");
                }
            }
           catch (Exception e)
            {
                
                return ($"Error de la Aplicacion: {e.Message}");
            }
        }
        public Pago BuscarxIdentificacion(string id){
            Pago pago= _context.Pagos.Find(id);
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

        public Pago pago { get; set; }

    }
}
