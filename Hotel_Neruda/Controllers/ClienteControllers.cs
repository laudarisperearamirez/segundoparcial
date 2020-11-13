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
        // GET: api/clienteControllers/5
        [HttpGet("{identificacion}")]
        public ActionResult<ClienteViewModel> Get(string identificacion)
        {
            var cliente = _clienteService.BuscarxIdentificacion(identificacion);
            if (cliente == null) return NotFound();
            var clienteViewModel = new ClienteViewModel(cliente);
            return clienteViewModel;
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
                Identificacion = clienteInput.Identificacion,
                PrimerNombre =  clienteInput.PrimerNombre,
                PrimerApellido=clienteInput.PrimerApellido,
                Telefono=clienteInput.Telefono,
                Direccion=clienteInput.Direccion,
                Ciudad=clienteInput.Ciudad,
                Departamento = clienteInput.Departamento,
                TipoIdentificacion = clienteInput.TipoIdentificacion,
                Pais=clienteInput.Pais,
                
            };
            return cliente;
        }
        
    }
}