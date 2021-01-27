using Microsoft.EntityFrameworkCore;


namespace api_gestores.NET.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<api_gestores.NET.Models.Gestores_bd> Gestores_bd { get; set; }
    }
}