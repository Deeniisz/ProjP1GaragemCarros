using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjGaragemDeCarrosWebAppAPICORE.Models;

namespace ProjGaragemDeCarrosWebAppAPICORE.Data
{
    public class ProjGaragemDeCarrosWebAppAPICOREContext : DbContext
    {
        public ProjGaragemDeCarrosWebAppAPICOREContext (DbContextOptions<ProjGaragemDeCarrosWebAppAPICOREContext> options)
            : base(options)
        {
        }

        public DbSet<ProjGaragemDeCarrosWebAppAPICORE.Models.Carro> Carro { get; set; }

        public DbSet<ProjGaragemDeCarrosWebAppAPICORE.Models.Cliente> Cliente { get; set; }

        public DbSet<ProjGaragemDeCarrosWebAppAPICORE.Models.Vendedor> Vendedor { get; set; }

        public DbSet<ProjGaragemDeCarrosWebAppAPICORE.Models.Venda> Venda { get; set; }
    }
}
