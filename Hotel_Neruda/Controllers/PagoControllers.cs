using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Hotel_Neruda.Models;
using Datos;
namespace Hotel_Neruda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoControllers : ControllerBase
    {
        private readonly PagoService _pagoService;
        public IConfiguration Configuration { get; }
        public PagoControllers(NerudaContext _context)
        {
            _pagoService=new PagoService(_context);
        }
        // GET: api/pago
        [HttpGet]
        public IEnumerable<PagoViewModel> Gets()
        {
            var  pagos = _pagoService.ConsultarTodos().Select(p=> new  PagoViewModel(p));
            return  pagos;
        }
        // POST: api/pago
        [HttpPost]
        public ActionResult<PagoViewModel> Post(PagoInputModel pagoInput)
        {
            Pago pago = MapearPago(pagoInput);
            var response = _pagoService.Guardar(pago);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar Pago", response.Mensaje);
                var problemDetails= new ValidationProblemDetails(ModelState){
                    Status= StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Pago);
        }
        private Pago MapearPago(PagoInputModel pagoInput)
        {
            var  pago = new Pago
            {
            Codigo= pagoInput.Codigo,
            Tipo=pagoInput.Tipo,
            Fecha=pagoInput.Fecha,
            ValorPago=pagoInput.ValorPago,
            ValorIva=pagoInput.ValorIva,
            Identificacion=pagoInput.Identificacion,
                
            };
            return pago;
        }
    }
}