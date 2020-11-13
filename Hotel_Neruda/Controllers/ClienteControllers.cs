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
namespace Parcial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteControllers: ControllerBase
    {
        private readonly ClienteService _clienteService;
        public IConfiguration Configuration { get; }
        public ClienteControllers(NerudaContext _context)
        {
            _clienteService=new ClienteService(_context);
        }
        // GET: api/cliente
        [HttpGet]
        public IEnumerable<ClienteViewModel> Gets()
        {
            var  clientes = _clienteService.ConsultarTodos().Select(p=> new  ClienteViewModel(p));
            return  clientes;
        }
        // POST: api/cliente
        [HttpPost]
        public ActionResult<ClienteViewModel> Post(ClienteInputModel clienteInput)
        {
            Cliente cliente = MapearCliente(clienteInput);
            var response = _clienteService.Guardar(cliente);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar Cliente", response.Mensaje);
                var problemDetails= new ValidationProblemDetails(ModelState){
                    Status= StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Cliente);
        }
        private Cliente MapearCliente(ClienteInputModel clienteInput)
        {
            var  cliente = new Cliente
            {
                Identificacion = clienteInput.identificacion,
                PrimerNombre =  clienteInput.primerNombre,
                SegundoNombre= clienteInput.segundoNombre,
                PrimerApellido=clienteInput.primerApellido,
                SegundoApellido=clienteInput.segundoApellido,
                Edad=clienteInput.edad,
                Genero=clienteInput.genero,
                Gmail=clienteInput.gmail,
                Telefono=clienteInput.telefono,
                Direccion=clienteInput.direccion,
                Ciudad=clienteInput.ciudad,
                
            };
            return cliente;
        }
        
    }
}