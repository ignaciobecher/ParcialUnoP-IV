using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParcialUnoP_IV.Models;

namespace ParcialUnoP_IV.Data
{
    public class ParcialUnoP_IVContext : DbContext
    {
        public ParcialUnoP_IVContext (DbContextOptions<ParcialUnoP_IVContext> options)
            : base(options)
        {
        }

        public DbSet<ParcialUnoP_IV.Models.Clientes> Clientes { get; set; } = default!;
        public DbSet<ParcialUnoP_IV.Models.Productos> Productos { get; set; } = default!;
        public DbSet<ParcialUnoP_IV.Models.Ventas> Ventas { get; set; } = default!;
    }
}
