using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Persistance
{
    public class ProjektApiDbContextFactory : DesignTimeDbContextFactoryBase<ProjektApiDbContext>
    {
        protected override ProjektApiDbContext CreateNewInstance(Microsoft.EntityFrameworkCore.DbContextOptions<ProjektApiDbContext> options)
        {
            return new ProjektApiDbContext(options);
        }
    }
}
