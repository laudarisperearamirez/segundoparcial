using Entidad;
namespace Hotel_Neruda.Models
{
    public class ClienteInputModel
    {
       public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string  PrimerApellido { get; set; }
        
        public string Departamento { get; set; }      
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
    }
    public class ClienteViewModel : ClienteInputModel

    {

        public ClienteViewModel()

        {

        }

        public ClienteViewModel(Cliente cliente)
        {
            Identificacion = cliente.Identificacion;
            PrimerNombre=cliente.PrimerNombre;
            PrimerApellido=cliente.PrimerApellido;
            Telefono=cliente.Telefono;
            TipoIdentificacion=cliente.Telefono;
            Direccion=cliente.Direccion;
            Departamento=cliente.Departamento;
            Pais=cliente.Pais;
            Ciudad=cliente.Ciudad;

        }

    }
}