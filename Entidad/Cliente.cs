using System.ComponentModel.DataAnnotations;
namespace Entidad{
    public class Cliente{
        
        [Key]
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
}