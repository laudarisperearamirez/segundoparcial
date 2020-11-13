using Microsoft.EntityFrameworkCore;
using Entidad;
namespace Datos
{
    public class NerudaContext : DbContext
    {
        public NerudaContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pago> Pago {get;set;}
   }
}
