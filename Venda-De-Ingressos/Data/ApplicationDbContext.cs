using Microsoft.EntityFrameworkCore;
using Venda_De_Ingressos.Models;

namespace Venda_De_Ingressos.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        }

        public DbSet<CasaDeShow> CasaDeShows { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}