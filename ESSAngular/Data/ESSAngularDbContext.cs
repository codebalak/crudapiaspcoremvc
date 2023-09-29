using ESSAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace ESSAngular.Data
{
    public class ESSAngularDbContext : DbContext
    {
        public ESSAngularDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }

    }
}
