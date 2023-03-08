using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BlazorAppMasterCrud
{
    public class ApDBContext : DbContext
    {
        public ApDBContext(DbContextOptions<ApDBContext> options) : base(options)
        {

        }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Service> Service { get; set; }

    }
}
